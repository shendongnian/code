    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace nthPrimeNumber
    {
        class Program
        {
            static void Main(string[] args)
            {
                ulong starting_number = 1;
                ulong last_number = 200000; //only this value needs adjustment
                ulong nth_primenumber = 0;
                ulong a;
                ulong b;
                ulong c;
                for (a = starting_number; a <= last_number; a++)
                {
                    b = Convert.ToUInt64(Math.Ceiling(Math.Sqrt(a)));
                    for (c = 2; c <= b; c++)
                    {
                        if (a == 1 || (a % c == 0 && c != b))
                        {
                            break;
                        }
                        else
                        {
                            if (c == b)
                            {
                                nth_primenumber = nth_primenumber + 1;
                                break;
                            }
                        }
                    }
                    if (nth_primenumber == 10001)
                    {
                        break;
                    }
                }
                Console.WriteLine(nth_primenumber + "st" + "prime number is " + a);
                Console.ReadKey();
            }
        }
    }
