    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace YieldReturnTest
    {
        public class PrimeFinder
        {
            private Boolean isPrime(int integer)
            {
                if (0 == integer)
                    return false;
                if (3 > integer)
                    return true;
                for (int i = 2; i < integer; i++)
                {
                    if (0 == integer % i)
                        return false;
                }
                return true;
            }
            public IEnumerable<int> FindPrimesWithYield()
            {
                int i;
                for (i = 1; i < 2147483647; i++)
                {
                    if (isPrime(i))
                    {
                        yield return i;
                    }
                }
            }
            public IEnumerable<int> FindPrimesWithoutYield()
            {
                var primes = new List<int>();
                int i;
                for (i = 1; i < 2147483647; i++)
                {
                    if (isPrime(i))
                    {
                        primes.Add(i);
                    }
                }
                return primes;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                PrimeFinder primes = new PrimeFinder();
                Console.WriteLine("Finding primes until 7 with yield...very fast...");
                foreach (int i in primes.FindPrimesWithYield()) // FindPrimesWithYield DOES NOT iterate over all integers at once, it returns item by item
                {
                    if (i > 7)
                    {
                        break;
                    }
                    Console.WriteLine(i);
                    //Console.ReadLine();
                
                }
                Console.WriteLine("Finding primes until 7 without yield...be patient it will take lonkg time...");
                foreach (int i in primes.FindPrimesWithoutYield()) // FindPrimesWithoutYield DOES iterate over all integers at once, it returns the complete list of primes at once
                {
                    if (i > 7)
                    {
                        break;
                    }
                    Console.WriteLine(i);
                    //Console.ReadLine();
                }
                Console.ReadLine();
                Console.ReadLine();
            }
        }
    }
