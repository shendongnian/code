    private static List<int> PrimeEvaluator(int number)
        {
            var result = new List<int>();
            // Take out the 2s
            while (number % 2 == 0)
            {
                result.Add(2);
                number /= 2;
            }
            // take out other primes
            int factor = 3;
            while (factor * factor <= number)
            {
                if (number % factor == 0)
                {
                    result.Add(factor);
                    number /= factor;
                }
                else
                    factor += 2;
            }
            // if num is not 1, then whatever is left is prime.
            if (number > 1) result.Add(number);
            return result;
        }
