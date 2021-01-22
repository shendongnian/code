    void prime_num(long num)
    {
        // bool isPrime = true;
        for (long i = 0; i <= num; i+=2)
        {
            bool isPrime = true; // Move initialization to here
            for (long j = 2; j < i; j++) // you actually only need to check up to sqrt(i)
            {
                if (i % j == 0) // you don't need the first condition
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine ( "Prime:" + i );
            }
            // isPrime = true;
        }
    }
