    public class PrimeNumbers : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator();
        }
    }
    
    public class MyEnumerator : IEnumerator
    {
        private int lastPrimeNumber = 1;
    
        public bool MoveNext()
        {
            lastPrimeNumber = /* some logic that find the next prime */;
            return true; // There is always next prime
        }
    
        public void Reset()
        {
            lastPrimeNumber = 1;
        }
    
        public object Current
        {
            get { return lastPrimeNumber; }
        }
    }
