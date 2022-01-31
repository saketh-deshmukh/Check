/*
 * Name: Saketh Deshmukh
 * Date: 01/30/2022
 * Description: Solution for 6 questions mentioned in DIS:Assignment 1
 */
using System;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1: Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string after removing the Vowels: {0}", final_string);
            Console.WriteLine();

            //NEXT

            //Question 2:
            string[] bulls_string1 = new string[] { "Marshall", "Student", "Center" };
            string[] bulls_string2 = new string[] { "MarshallStudent", "Center" };
            Console.WriteLine("Q2");
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            if (flag)
            {
                Console.WriteLine("Yes, Both the array’s represent the same string");
            }
            else
            {
                Console.WriteLine("No, Both the array’s don’t represent the same string ");
            }
            Console.WriteLine();

            //NEXT

            //Question 3:
            int[] bull_bucks = new int[] { 1, 2, 3, 2 };
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Q3:");
            Console.WriteLine("Sum of Unique Elements in the array are :{0}", unique_sum);
            Console.WriteLine();

            //NEXT

            //Question 4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Q4:");
            int diagSum = DiagonalSum(bulls_grid);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is: {0}", diagSum);
            Console.WriteLine();

            //NEXT

            //Question 5:
            Console.WriteLine("Q5:");
            String bulls_string = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("The  Final string after rotation is: {0}", rotated_string);
            Console.WriteLine();

            //NEXT

            //Quesiton 6:
            string bulls_string6 = "mumacollegeofbusiness";
            char ch = 'c';
            Console.WriteLine("Q6:");
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("Resultant string are reversing the prefix: {0}", reversed_string);
            Console.WriteLine();
        }
        private static string RemoveVowels(string s)
        {
            try
            {
                // write your code here
                String final_string = "";
                int len = s.Length;
                if (len > 10000)//user defined exceptions
                {
                    throw new MaxLengths(len);
                }
                for (int i = 0; i < s.Length; i++)//looping along the string
                {
                    if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')//checking for lower case vowels
                    {
                        final_string = final_string + "";
                    }
                    else if (s[i] == 'A' || s[i] == 'E' || s[i] == 'I' || s[i] == 'O' || s[i] == 'U')//checking for upper case vowels
                    {
                        final_string = final_string + "";
                    }
                    else
                        final_string = final_string + s[i];//adding consonents to the final string
                }


                return final_string;//return final string
            }
            catch (Exception)
            {
                throw;
            }

        }


        private static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {
            try
            {
                // write your code here.
                string s1 = "";
                string s2 = "";
                for (int i = 0; i < bulls_string1.Length; i++)//adding all strings in the array to a single string
                {
                    s1 = s1 + bulls_string1[i];
                }
                for (int i = 0; i < bulls_string2.Length; i++)//adding all the strings in the array to a single string
                {
                    s2 = s2 + bulls_string2[i];
                }
                if (s1 == s2)//comparing the final strings
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static int SumOfUnique(int[] bull_bucks)
        {
            try
            {
                // write your code here
                int a = 0;
                int len = bull_bucks.Length;
                if (len > 100)//user defined exceptions
                {
                    throw new MaxLengths(len);
                }
                foreach (int i in bull_bucks)//user defined exceptions
                {
                    if (i > 100)
                    {
                        throw new MaxValues(i);
                    }
                }
                for (int j = 0; j < bull_bucks.Length - 1; j++)
                {
                    for (int k = j + 1; k < bull_bucks.Length; k++)
                    {
                        if (bull_bucks[j] > bull_bucks[k])
                        {
                            int x = bull_bucks[j];
                            bull_bucks[j] = bull_bucks[k];
                            bull_bucks[k] = x;
                        }
                    }
                }
                //Array.Sort(bull_bucks);

                int n = bull_bucks.Length;
                for (int i = 0; i < bull_bucks.Length - 1; i++)
                {
                    if (bull_bucks[i] == bull_bucks[i + 1])//substracting the duplicate element
                        a = a - bull_bucks[i];
                    else if (bull_bucks[i] != bull_bucks[i + 1])//adding unique elements
                        a = a + bull_bucks[i];

                }
                a = a + bull_bucks[bull_bucks.Length - 1];
                if (a > 0)
                    return a;
                else
                    return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static int DiagonalSum(int[,] bulls_grid)
        {
            try
            {
                int l = bulls_grid.GetLength(0);
                int diagsum = 0;
                // write your code here.
                for (int i = 0; i < l; i++)//looping around the 2D array
                {
                    for (int j = 0; j < l; j++)
                    {
                        if ((i == j) || ((i + j) == l - 1))
                        {
                            diagsum = diagsum + bulls_grid[i, j];//adding the diagnol elements

                        }
                    }
                }
                return diagsum;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        private static string RestoreString(string bulls_string, int[] indices)
        {
            try
            {
                // write your code here.
                string rotated_string = "";
                int len = bulls_string.Length;
                if (len > 100)//user defined exceptions
                {
                    throw new MaxLengths(len);
                }
                if (bulls_string.Length != indices.Length)//user defined exceptions
                {
                    throw new NotSame();
                }
                if (bulls_string.Any(char.IsUpper))//user defined exceptions
                {
                    throw new Uppers();
                }
                if (indices.Distinct().Count() != indices.Length)//user defined exceptions
                {
                    throw new Repeat();
                }
                char[] a = new char[indices.Length]; // storing given string in char format
                int[] b = new int[bulls_string.Length];
                char[] result = new char[bulls_string.Length];
                int t = 0;
                foreach (char c in bulls_string)// traversing through the entire string
                {
                    a[t] = c; //copying content to char array
                    t++;
                }
                for (int i = 0; i < bulls_string.Length; i++) // mapping the indices to appropriate character
                {
                    result[indices[i]] = a[i];
                }
                foreach (char c in result)
                {
                    rotated_string = rotated_string + c.ToString();//adding char to the final string
                }

                return rotated_string;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        private static string ReversePrefix(string bulls_string6, char ch)
        {
            try
            {
                String prefix_string = "";
                int len = bulls_string6.Length;
                if (bulls_string6.Any(char.IsUpper))//user defined exceptions
                {
                    throw new Uppers();
                }
                if (len > 250)//user defined exceptions
                {
                    throw new MaxLengths(len);
                }
                int flag = 0;//declaring flag
                for (int i = 0; i < bulls_string6.Length; i++)
                {
                    if (bulls_string6[i] == ch)//checking for the char
                    {
                        int length = i;//setting i value as length
                        flag = 1;//setting flag
                        while (length >= 0)//looping while reducing length value
                        {
                            prefix_string = prefix_string + bulls_string6[length];
                            length--;
                        }
                    }
                    else if (flag == 1)//checking for the flag, its set to 1 only after the char is found
                    {
                        prefix_string = prefix_string + bulls_string6[i];
                    }
                }
                return prefix_string;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
[Serializable]
public class MaxLengths : Exception
{
    public MaxLengths(int l)
    {
        Console.WriteLine("Lenght of input string should be less than " + l);
    }
}
public class MaxValues : Exception
{
    public MaxValues(int i)
    {
        Console.WriteLine("Value of the input should not exceed 100, current value: " + i);
    }
}
public class Uppers : Exception
{
    public Uppers()
    {
        Console.WriteLine("Input string contains Upper case letter");
    }
}

public class Repeat : Exception
{
    public Repeat()
    {
        Console.WriteLine("All the values in indices array should be unique");
    }
}

public class NotSame : Exception
{
    public NotSame()
    {
        Console.WriteLine("Indices length and bull_string length are not same");
    }
}
public class OutOflength : Exception
{
    public OutOflength()
    {
        Console.WriteLine("Value in indices is exceeding the number of characters in the string");
    }
}
