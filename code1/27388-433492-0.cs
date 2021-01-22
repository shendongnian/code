    using System;
    using System.Diagnostics;
    namespace Euler_Problem_4
    {
        class Program
        {
            static void Main(string[] args)
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                int t = 0;
                for (int i = 999; i > 99; i--)
                {
                    for (int j = i; j > 99; j--)
                    {
                        if (i*j == FastReverse(i*j))
                        {
                            if (i * j > t)
                            {
                                t = i * j;
                            }
                        }
                    }
                }
                Console.WriteLine(t);
                s.Stop();
                Console.WriteLine("{0}mins {1}secs {2}ms", s.Elapsed.Minutes, s.Elapsed.Seconds, s.Elapsed.Milliseconds);
                Console.ReadKey(true);
            }
            private static int FastReverse(int num)
            {
                int res = 0;
                int q = (int)((214748365L * num) >> 31);
                int rm = num - 10 * q;
                num = q;
                if (rm == 0) return -1;
                res = res * 10 + rm;
                while (num > 0)
                {
                    q = (int)((214748365L * num) >> 31);
                    rm = num - 10 * q;
                    num = q;
                    res = res * 10 + rm;
                }
                return res;
            }
        }
    }
