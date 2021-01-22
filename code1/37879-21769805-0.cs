        bool IsPowerOfTwo(int n)
        {
            if (n > 1)
            {
                while (n%2 == 0 && n != 1)
                {
                    n >>= 1;
                }
            }
            return n == 1;
        }
