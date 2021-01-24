    using System;
    namespace Demo
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                const int M = 10;
                int[,,] f = new int [M + 1, 11, 2];
                f[0, 0, 0] = 1;
                for (int len = 1; len <= M; ++len)
                {
                    for (int d = 0; d <= 9; ++d)
                    {
                        for (int j = 0; j <= 9; ++j)
                        {
                            f[len,d,0] += f[len - 1,j,0];
                            f[len,d,1] += f[len - 1,j,1];
                        }
                    }
                    f[len,4,0] -= f[len - 1,1,0];
                    f[len,4,1] += f[len - 1,1,0];
                }
                int sum = 0;
                for (int i = 0; i <= 9; ++i)
                    sum += f[M,i,1];
                Console.WriteLine(sum); // 872,348,501
            }
        }
    }
