    public static class PrimeHelper
    {
        static PrimeHelper()
        {
            primes = new PrimesInt32(10000000);
        }
        
        private static PrimesInt32 primes { get; set; }
        public static IEnumerable<Int32> FindPrimes(Int32 maxNumber)
        {
            if (primes != null && maxNumber <= primes.Max())
                return primes.Where(pn => pn <= maxNumber);
            else
                return (new PrimesInt32(maxNumber));
            
        }
        public static IEnumerable<Int32> FindPrimes(Int32 minNumber, Int32 maxNumber)
        {
            if (primes != null && maxNumber <= primes.Max())
                return primes.Where(pn => pn >= minNumber && pn <= maxNumber).ToList();
            else
                return FindPrimes(maxNumber).Where(pn => pn >= minNumber);
        }
        public static bool IsPrime(this Int64 number)
        {
            if (number < 2)
                return false;
            else if (number < 4 )
                return true;
            if (primes != null && primes.IsDivisible(number))
                return false;
            var limit = (Int32)System.Math.Sqrt(number);
            var foundPrimes = new PrimesInt32(limit);
            if (foundPrimes.Count() > primes.Count())
                primes = foundPrimes;
            return !foundPrimes.IsDivisible(number);
        }
        public static bool IsPrime(this Int32 number)
        {
            return IsPrime(Convert.ToInt64(number));
        }
        public static bool IsPrime(this Int16 number)
        {
            return IsPrime(Convert.ToInt64(number));
        }
 
        public static bool IsPrime(this byte number)
        {
            return IsPrime(Convert.ToInt64(number));
        }
    }
    public class PrimesInt32 : IEnumerable<Int32>
    {
        private Int32 limit;
        private BitArray numbers;
        public PrimesInt32(Int32 limit)
        {
            startTime = DateTime.Now;
            lastCalculateTime = startTime - startTime;
            this.limit = limit;
            findPrimes();
            lastCalculateTime = DateTime.Now - startTime;
        }
        private void findPrimes()
        {
            /*
            The Sieve Algorithm
            http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
            */
            numbers = new BitArray(limit + 1, true);
            for (Int32 i = 2; i < limit; i++)
                if (numbers[i])
                    for (Int32 j = i * 2; j < limit; j += i)
                         numbers[j] = false;
        }
        public IEnumerator<Int32> GetEnumerator()
        {
            for (Int32 i = 2; i < 3; i++)
                if (numbers[i])
                    yield return i;
            if (limit > 2)
                for (Int32 i = 3; i < limit; i += 2)
                    if (numbers[i])
                        yield return i;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        // Extend for Int64
        public bool IsDivisible(Int64 number)
        {
            var sqrt = System.Math.Sqrt(number);
            foreach (var prime in this)
            {
                if (prime > sqrt)
                    break;
                if (number % prime == 0)
                    return true;
                
            }
            return false;
        }
        private static DateTime startTime;
        private static TimeSpan lastCalculateTime;
        public static TimeSpan LastCalculateTime { get { return lastCalculateTime; } }
    }
