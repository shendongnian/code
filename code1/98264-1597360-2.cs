    public class PrimeNumbers : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var primes = new List<int> { 2, 3, 5, 7, 11 };
            return primes.GetEnumerator();
        }
    }
