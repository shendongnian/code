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
     
            public IEnumerable<int> FindPrimes()
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
        }
       
        class Program
        {
            static void Main(string[] args)
            {
                PrimeFinder primes = new PrimeFinder();
     
                foreach (int i in primes.FindPrimes())
                {
                    Console.WriteLine(i);
                    Console.ReadLine();
                }
     
                Console.ReadLine();
                Console.ReadLine();
            }
        }
    }
