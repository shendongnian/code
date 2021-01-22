    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace PrimeNUmber
    {
        class Program
        {
            static void FindPrimeNumber(long num)
            {
                for (long i = 1; i <= num; i++)
                {
                    int totalFactors = 0;
                    for (int j = 1; j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            totalFactors = totalFactors + 1;
                        }
                    }
                    if (totalFactors == 2)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
    
            static void Main(string[] args)
            {
                long num;
                Console.WriteLine("Enter any value");
                num = Convert.ToInt64(Console.ReadLine());
                FindPrimeNumber(num);
                Console.ReadLine();
            }
        }
    }
