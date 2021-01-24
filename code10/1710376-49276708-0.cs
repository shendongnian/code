    using System;
    
    class Test
    {
        static double[,] ConvertMatrix(double[] flat, int m, int n)
        {
            if (flat.Length != m * n)
            {
                throw new ArgumentException("Invalid length");
            }
            double[,] ret = new double[m, n];
            // BlockCopy uses byte lengths: a double is 8 bytes
            Buffer.BlockCopy(flat, 0, ret, 0, flat.Length * sizeof(double));
            return ret;
        }
    
        static void Main()
        {
            double[] d = { 2, 5, 3, 5, 1, 6 };
    
            double[,] matrix = ConvertMatrix(d, 3, 2);
    
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine("matrix[{0},{1}] = {2}", i, j, matrix[i, j]);
                }
            }
        }
    }
