    public class PrimeFinder
    {
        readonly List<long> _primes = new List<long>();
        public PrimeFinder(long seed)
        {
            CalcPrimes(seed);
        }
        public List<long> Primes { get { return _primes; } }
        private void CalcPrimes(long maxValue)
        {
            for (int checkValue = 3; checkValue <= maxValue; checkValue += 2)
            {
                if (IsPrime(checkValue))
                {
                    _primes.Add(checkValue);
                }
            }
        }
        private bool IsPrime(long checkValue)
        {
            bool isPrime = true;
            foreach (long prime in _primes)
            {
                if ((checkValue % prime) == 0 && prime <= Math.Sqrt(checkValue))
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
    }
