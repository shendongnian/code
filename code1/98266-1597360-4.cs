    public class PrimeNumbers : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for(int i=2; ;i++)
            {
                if(IsPrime(i))
                {
                    yield return i;
                }
            }
        }
    }
