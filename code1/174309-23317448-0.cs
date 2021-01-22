        public static bool isPrime(int number)
        {
            for (int k = 2; k <= Math.Ceiling(Math.Sqrt(number)); k++)
            {
                if (number > k && number % k == 0)
                    break;
                if (k >= Math.Ceiling(Math.Sqrt(number)) || number == k)
                {
                    return true;
                }
            }
            return false;
        }
