        for (int i = 1; i < N; i++)
        {
            if (N % i == 0)
            {
                Console.WriteLine(i.ToString());
                product *= i;
            }
            if (product > 10000 * N)
            {
                product %= 10000;
            }
        }
