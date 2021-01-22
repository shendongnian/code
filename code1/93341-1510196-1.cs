    void prime_num(long num)
    {
        // bool isPrime = true;
        for (int i = 0; i <= num; i++)
        {
            bool isPrime = true; // Move initialization to here
            for (int j = 2; j < i; j++) // you actually only need to check up to sqrt(i)
            {
                if (i % j == 0) // you don't need the first condition
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
            Console .WriteLine ( "Prime:" + i );
            }
            // isPrime = true;
        }
    }
