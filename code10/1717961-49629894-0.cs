    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Euler._1_50
    {
        class Challenge3_1
        {
            List<long> primes = new List<long>();
            List<bool> isPrime = new List<bool>();
            List<int> factors = new List<int>();
            
            long primeNums = 0;
            long bigNum = 600_851_475_143;
            int primeBnds = 1_000_000;
    
            public Challenge3_1()
            {
                genList();
                getPrimes();
                //listPrimes();
                factor();
    
                Console.WriteLine("final");
                listFactors();
            }
    
    
            //not currently being used
            private void genList()
            {
                for (int i = 0; i <= primeBnds; i++)
                {
                    isPrime.Add(true);
                }
            }
    
            private void getPrimes()
            {
                isPrime[0] = false;
                isPrime[1] = false;
    
                for (int i = 2; i <= primeBnds; i++)
                {
                    if (isPrime[i] == true)
                    {
                        for (int j = i, index = 0; index <= primeBnds; index += j)
                        {
                            if (j < index)
                            {
                                isPrime[index] = false;
                            }
                        }
                    }
                }
            }
    
            private void factor()
            {
                long temp = bigNum;
    
                for (int i = 2; i <= primeBnds;)
                {
                    if (isPrime[i] == true && temp % i == 0)
                    {
                        temp = temp / i;
                        factors.Add(i);
                        Console.WriteLine(i);
                    }
    
                    if (temp % i != 0)
                    {
                        i++;
                    }
                    
                    //if (factors.Capacity != 0) listFactors();
                }
    
            }
    
            private void listPrimes()
            {
                for (int i = 0; i <= primeBnds; i++)
                {
                    if (isPrime[i] == true)
                    {
                        Console.WriteLine(++primeNums + " " + i);
                    }
                }
            }
    
            private void listFactors()
            {
                for (int i = 0; i < factors.Capacity; i++)
                {
                    Console.Write(factors[i] + " ");
                }
            }
    
        }
    }
