    public static class PrimeHelper
    {
        public static IEnumerable<Int32> FindPrimes(Int32 maxNumber)
        {
            return (new PrimesInt32(maxNumber));
        }
        public static IEnumerable<Int32> FindPrimes(Int32 minNumber, Int32 maxNumber)
        {
            return FindPrimes(maxNumber).Where(pn => pn >= minNumber);
        }
        public static bool IsPrime(this Int64 number)
        {
            if (number < 2)
                return false;
            else if (number < 4 )
                return true;
            var limit = (Int32)System.Math.Sqrt(number) + 1;
            var foundPrimes = new PrimesInt32(limit);
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
            if (limit < 2)
                throw new Exception("Prime numbers not found.");
            startTime = DateTime.Now;
            calculateTime = startTime - startTime;
            this.limit = limit;
            try { findPrimes(); } catch{/*Overflows or Out of Memory*/}
            
            calculateTime = DateTime.Now - startTime;
        }
        private void findPrimes()
        {
            /*
            The Sieve Algorithm
            http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
            */
            numbers = new BitArray(limit, true);
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
        // Extended for Int64
        public bool IsDivisible(Int64 number)
        {
            var sqrt = System.Math.Sqrt(number);
            foreach (var prime in this)
            {
                if (prime > sqrt)
                    break;
                if (number % prime == 0)
                {
                    DivisibleBy = prime;
                    return true;
                }
            }
            return false;
        }
        private static DateTime startTime;
        private static TimeSpan calculateTime;
        public static TimeSpan CalculateTime { get { return calculateTime; } }
        public Int32 DivisibleBy { get; set; }
    }
