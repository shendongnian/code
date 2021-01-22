    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace PrimeGenerator
    {
        public class Eratosthenes : Primes
        {
            protected BitArray mbaEliminated;
    
            public Eratosthenes(int limit)
                : base(limit)
            {
                if (mbaEliminated == null) FindPrimes();
            }
    
            public override IEnumerator<int> GetEnumerator()
            {
                yield return 2;
                for (int lsN = 3; lsN <= msLimit; lsN+=2)
                    if (!mbaEliminated[(int)lsN]) yield return lsN;
            }
    
            private void FindPrimes()
            {
                mbaEliminated = new BitArray(msLimit + 1);
                int lsSQRT = (int)Math.Sqrt(msLimit);
                for (int lsN = 3; lsN < lsSQRT + 1; lsN += 2)
                    if (!mbaEliminated[lsN])
                        for (int lsM = lsN * lsN; lsM <= msLimit; lsM += 2*lsN)
                            mbaEliminated[lsM] = true;
            }
        }
    }
