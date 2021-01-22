    void simplify(int[] numbers)
    {
        int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43,47};
        for (int divideBy = 50; divideBy > 0; divideBy--)
        {
            bool divisible = true;
            foreach (int cur in numbers)
            {   
    
                //check for primality
                if (primes.Contains(cur))
                {
                    return;
                }
                //check for divisibility
                if ((int)(cur/divideBy)*divideBy!=cur){
                    divisible = false;
                    break;
                }
            }
            if (divisible)
            {
                for (int i = 0; i < numbers.GetLength(0);i++ )
                {
                    numbers[i] /= divideBy;
                }
            }
        }
    }
