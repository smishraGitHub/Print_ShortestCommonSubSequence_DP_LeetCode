using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_ShortestCommonSubSequence_DP_LeetCode
{
    /// <summary>
    /// This code is a variation of Longest Common SubSequence
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //string q = "AGGTAB";
            //string p = "GXTXAYB";

            string q = "CAB";
            string p = "ABAC";


            int[,] tempResult = LCS(p, q, p.Length, q.Length);
            string printSCS = print_SCS(p, q, p.Length, q.Length, tempResult);
            Console.WriteLine("Shortest Common SubSequence " + printSCS);
            Console.ReadLine();

        }
        static string print_SCS(string x,string y,int m,int n,int[,] temp)
        {
            string Result = "";
            while(m>0 && n>0)
            {
                if(x[m-1] == y[n-1])
                {
                    Result = Result + Convert.ToString(x[m-1]);
                    m--;
                    n--;
                }
                else
                {
                    if (temp[m, n-1] > temp[m-1, n])
                    {
                        Result = Result + Convert.ToString(y[n-1]);
                        n--;
                    }
                    else if(temp[m-1,n]>= temp[m,n-1])
                    {
                        Result = Result + Convert.ToString(x[m-1]);
                        m--;
                    }
                }
            }
            while(n>0)
            {
                Result = Result + Convert.ToString(y[n-1]);
                n--;
            }
            while(m>0)
            {
                Result = Result + Convert.ToString(x[m-1]);
                m--;
            }

            //Reverse string for actual result
            string finalResult = "";
            for (int i=Result.Length-1;i>=0;i--)
            {
                finalResult = finalResult + Convert.ToString(Result[i]);
            }

            ///////////////////////////
            return finalResult;
            
        }
        static int[,] LCS(string x,string y,int m,int n)
        {
            int[,] temp = new int[m + 1, n + 1];
            //Base Condition
            for (int i = 0; i < m + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (i == 0 || j == 0)
                        temp[i, j] = 0;
                }
            }
            //Choice Diagram

            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (x[i - 1] == y[j - 1])
                    {
                        temp[i, j] = 1 + temp[i - 1, j - 1];
                    }
                    else
                    {
                        temp[i, j] = Math.Max(temp[i - 1, j], temp[i, j - 1]);
                    }
                }
            }
            return temp;
            }
        }
    }

