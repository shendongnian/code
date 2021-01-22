        static void Spiral(int[,] m)
        {
            int n = m.GetUpperBound(0);
            for (int i = 0; i < n / 2; ++i)
            {
                for (int j = i; j <= n - i; ++j)
                    Console.Write(m[i, j] + " ");
                for (int j = i + 1; j <= n - i; ++j)
                    Console.Write(m[j, n - i] + " ");
                for (int j = i + 1; j <= n - i; ++j)
                    Console.Write(m[n - i, n - j] + " ");
                for (int j = i + 1; j < n - i; ++j)
                    Console.Write(m[n - j, i] + " ");
            }
            Console.WriteLine(m[n / 2, n / 2]);
        }
        static void Main(string[] args)
        {
            int[,] myArray = new int[,]{
                {11, 12, 13, 14, 15},
                {21, 22, 23, 24, 25},
                {31, 32, 33, 34, 35},
                {41, 42, 43, 44, 45},
                {51, 52, 53, 54, 55}
            };
            Spiral(myArray);
        }
