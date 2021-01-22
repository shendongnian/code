    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    namespace PrimeGenerator
    {
        public class Atkin : Primes
        {
            protected BitArray mbaPrimes;
            protected bool mbThreaded = true;
    
            public Atkin(int limit)
                : this(limit, true)
            {
            }
    
            public Atkin(int limit, bool threaded)
                : base(limit)
            {
                mbThreaded = threaded;
                if (mbaPrimes == null) FindPrimes();
            }
    
            public bool Threaded
            {
                get
                {
                    return mbThreaded;
                }
            }
    
            public override IEnumerator<int> GetEnumerator()
            {
                yield return 2;
                yield return 3;
                for (int lsN = 5; lsN <= msLimit; lsN += 2)
                    if (mbaPrimes[lsN]) yield return lsN;
            }
    
            private void FindPrimes()
            {
                mbaPrimes = new BitArray(msLimit + 1, false);
    
                int lsSQRT = (int)Math.Sqrt(msLimit);
    
                int[] lsSquares = new int[lsSQRT + 1];
                for (int lsN = 0; lsN <= lsSQRT; lsN++)
                    lsSquares[lsN] = lsN * lsN;
    
                if (Threaded)
                {
                    CompartmentalisedParallel.For<BitArray>(
                        1, lsSQRT + 1, new ParallelOptions(),
                        (start, finish) => { return new BitArray(msLimit + 1, false); },
                        (lsX, lsState, lbaLocal) =>
                        {
                            int lsX2 = lsSquares[lsX];
    
                            for (int lsY = 1; lsY <= lsSQRT; lsY++)
                            {
                                int lsY2 = lsSquares[lsY];
    
                                int lsN = 4 * lsX2 + lsY2;
                                if (lsN <= msLimit && (lsN % 12 == 1 || lsN % 12 == 5))
                                    lbaLocal[lsN] ^= true;
    
                                lsN -= lsX2;
                                if (lsN <= msLimit && lsN % 12 == 7)
                                    lbaLocal[lsN] ^= true;
    
                                if (lsX > lsY)
                                {
                                    lsN -= lsY2 * 2;
                                    if (lsN <= msLimit && lsN % 12 == 11)
                                        lbaLocal[lsN] ^= true;
                                }
                            }
    
                            return lbaLocal;
                        },
                        (lbaResult, start, finish) =>
                        {
                            lock (mbaPrimes) 
                                mbaPrimes.Xor(lbaResult);
                        },
                        -1
                    );
                }
                else
                {
                    for (int lsX = 1; lsX <= lsSQRT; lsX++)
                    {
                        int lsX2 = lsSquares[lsX];
    
                        for (int lsY = 1; lsY <= lsSQRT; lsY++)
                        {
                            int lsY2 = lsSquares[lsY];
    
                            int lsN = 4 * lsX2 + lsY2;
                            if (lsN <= msLimit && (lsN % 12 == 1 || lsN % 12 == 5))
                                mbaPrimes[lsN] ^= true;
    
                            lsN -= lsX2;
                            if (lsN <= msLimit && lsN % 12 == 7)
                                mbaPrimes[lsN] ^= true;
    
                            if (lsX > lsY)
                            {
                                lsN -= lsY2 * 2;
                                if (lsN <= msLimit && lsN % 12 == 11)
                                    mbaPrimes[lsN] ^= true;
                            }
                        }
                    }
                }
    
                for (int lsN = 5; lsN < lsSQRT; lsN += 2)
                    if (mbaPrimes[lsN])
                    {
                        var lsS = lsSquares[lsN];
                        for (int lsK = lsS; lsK <= msLimit; lsK += lsS)
                            mbaPrimes[lsK] = false;
                    }
            }
        }
    }
