    using System.Collections;
    using System.Collections.Generic;
    
    namespace PrimeGenerator
    {
        public abstract class Primes : IEnumerable<int>
        {
            protected readonly int msLimit;
    
            public Primes(int limit)
            {
                msLimit = limit;
            }
    
            public int Limit
            {
                get
                {
                    return msLimit;
                }
            }
    
            public int Count
            {
                get
                {
                    int liCount = 0;
                    foreach (int liPrime in this)
                        liCount++;
                    return liCount;
                }
            }
    
            public abstract IEnumerator<int> GetEnumerator();
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
