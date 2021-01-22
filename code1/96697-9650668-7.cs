    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace PrimeGenerator
    {
        public class Eratosthenes : Primes
        {
            protected BitArray mbaOddEliminated;
    
            public Eratosthenes(int limit)
                : base(limit)
            {
                if (mbaOddEliminated == null) FindPrimes();
            }
    
            public override IEnumerator<int> GetEnumerator()
            {
                yield return 2;
                for (int lsN = 3; lsN <= msLimit; lsN+=2)
                    if (!mbaOddEliminated[lsN>>1]) yield return lsN;
            }
    
            private void FindPrimes()
            {
                mbaOddEliminated = new BitArray((msLimit>>1) + 1);
                int lsSQRT = (int)Math.Sqrt(msLimit);
                for (int lsN = 3; lsN < lsSQRT + 1; lsN += 2)
                    if (!mbaOddEliminated[lsN>>1])
                        for (int lsM = lsN*lsN; lsM <= msLimit; lsM += lsN<<1)
                            mbaOddEliminated[lsM>>1] = true;
            }
        }
    }
