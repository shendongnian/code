        bool IsPowerOf(int n,int b)
        {
            if (n > 1)
            {
                while (n % b == 0 && n != 1)
                {
                    n /= b;
                }
            }
            return n == 1;
        }
