        bool IsPowerOf(int n,int b)
        {
            if (n > 1)
            {
                while (n % b == 0)
                {
                    n /= b;
                }
            }
            return n == 1;
        }
