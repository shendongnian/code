    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace PrimeGenerator
    {
        // The block element type for the bit array, 
        // use any unsigned value. WARNING: UInt64 is 
        // slower even on x64 architectures.
        using BitArrayType = System.UInt32;
    
        // This should never be any bigger than 256 bits - leave as is.
        using BitsPerBlockType = System.Byte;
    
        // The prime data type, this can be any unsigned value, the limit
        // of this type determines the limit of Prime value that can be
        // found. WARNING: UInt64 is slower even on x64 architectures.
        using PrimeType = System.Int32;
    
        /// <summary>
        /// Calculates prime number using the Sieve of Eratosthenes method.
        /// </summary>
        /// <example>
        /// <code>
        ///     var lpPrimes = new Eratosthenes(1e7);
        ///     foreach (UInt32 luiPrime in lpPrimes)
        ///         Console.WriteLine(luiPrime);
        /// </example>
        public class Atkin : IEnumerable<PrimeType>
        {
            #region Constants
    
            /// <summary>
            /// Constant for number of bits per block, calculated based on size of BitArrayType.
            /// </summary>
            const BitsPerBlockType cbBitsPerBlock = sizeof(BitArrayType) * 8;
    
            #endregion
    
            #region Protected Locals
    
            /// <summary>
            /// The limit for the maximum prime value to find.
            /// </summary>
            protected readonly PrimeType mpLimit;
    
            /// <summary>
            /// The number of primes calculated or null if not calculated yet.
            /// </summary>
            protected PrimeType? mpCount = null;
    
            /// <summary>
            /// The current bit array where a set bit means
            /// the odd value at that location has been determined
            /// to not be prime.
            /// </summary>
            protected BitArrayType[] mbaOddPrime;
    
            #endregion
    
            #region Initialisation
    
            /// <summary>
            /// Create Sieve of Atkin generator.
            /// </summary>
            /// <param name="limit">The limit for the maximum prime value to find.</param>
            public Atkin(PrimeType limit)
            {
                // Check limit range
                if (limit > PrimeType.MaxValue - (PrimeType)Math.Sqrt(PrimeType.MaxValue))
                    throw new ArgumentOutOfRangeException();
    
                mpLimit = limit;
    
                FindPrimes();
            }
    
            #endregion
    
            #region Private Methods
    
            /// <summary>
            /// Finds the prime number within range.
            /// </summary>
            private unsafe void FindPrimes()
            {
                // Allocate bit array.
                mbaOddPrime = new BitArrayType[(((mpLimit >> 1) + 1) / cbBitsPerBlock) + 1];
    
                PrimeType lpYLimit, lpN, lpXX3, lpXX4, lpDXX, lpDN, lpDXX4, lpXX, lpX, lpYY, lpMinY, lpS, lpK;
    
                fixed (BitArrayType* lpbOddPrime = &mbaOddPrime[0])
                {
                    // n = 3x^2 + y^2 section
                    lpXX3 = 3;
                    for (lpDXX = 0; lpDXX < 12 * SQRT((mpLimit - 1) / 3); lpDXX += 24)
                    {
                        lpXX3 += lpDXX;
                        lpYLimit = (12 * SQRT(mpLimit - lpXX3)) - 36;
                        lpN = lpXX3 + 16;
    
                        for (lpDN = -12; lpDN < lpYLimit + 1; lpDN += 72)
                        {
                            lpN += lpDN;
                            lpbOddPrime[(lpN >> 1) / cbBitsPerBlock] ^= 
                                (BitArrayType)((BitArrayType)1 << (int)((lpN >> 1) % cbBitsPerBlock));
                        }
    
                        lpN = lpXX3 + 4;
                        for (lpDN = 12; lpDN < lpYLimit + 1; lpDN += 72)
                        {
                            lpN += lpDN;
                            lpbOddPrime[(lpN >> 1) / cbBitsPerBlock] ^= 
                                (BitArrayType)((BitArrayType)1 << (int)((lpN >> 1) % cbBitsPerBlock));
                        }
                    }
    
                    //    # n = 4x^2 + y^2 section
                    lpXX4 = 0;
                    for (lpDXX4 = 4; lpDXX4 < 8 * SQRT((mpLimit - 1) / 4) + 4; lpDXX4 += 8)
                    {
                        lpXX4 += lpDXX4;
                        lpN = lpXX4 + 1;
    
                        if ((lpXX4 % 3) != 0)
                        {
                            for (lpDN = 0; lpDN < (4 * SQRT(mpLimit - lpXX4)) - 3; lpDN += 8)
                            {
                                lpN += lpDN;
                                lpbOddPrime[(lpN >> 1) / cbBitsPerBlock] ^= 
                                    (BitArrayType)((BitArrayType)1 << (int)((lpN >> 1) % cbBitsPerBlock));
                            }
                        }
                        else
                        {
                            lpYLimit = (12 * SQRT(mpLimit - lpXX4)) - 36;
                            lpN = lpXX4 + 25;
    
                            for (lpDN = -24; lpDN < lpYLimit + 1; lpDN += 72)
                            {
                                lpN += lpDN;
                                lpbOddPrime[(lpN >> 1) / cbBitsPerBlock] ^= 
                                    (BitArrayType)((BitArrayType)1 << (int)((lpN >> 1) % cbBitsPerBlock));
                            }
    
                            lpN = lpXX4 + 1;
                            for (lpDN = 24; lpDN < lpYLimit + 1; lpDN += 72)
                            {
                                lpN += lpDN;
                                lpbOddPrime[(lpN >> 1) / cbBitsPerBlock] ^= 
                                    (BitArrayType)((BitArrayType)1 << (int)((lpN >> 1) % cbBitsPerBlock));
                            }
                        }
                    }
    
                    //    # n = 3x^2 - y^2 section
                    lpXX = 1;
                    for (lpX = 3; lpX < SQRT(mpLimit / 2) + 1; lpX += 2)
                    {
                        lpXX += 4 * lpX - 4;
                        lpN = 3 * lpXX;
    
                        if (lpN > mpLimit)
                        {
                            lpMinY = ((SQRT(lpN - mpLimit) >> 2) << 2);
                            lpYY = lpMinY * lpMinY;
                            lpN -= lpYY;
                            lpS = 4 * lpMinY + 4;
                        }
                        else
                            lpS = 4;
    
                        for (lpDN = lpS; lpDN < 4 * lpX; lpDN += 8)
                        {
                            lpN -= lpDN;
                            if (lpN <= mpLimit && lpN % 12 == 11)
                                lpbOddPrime[(lpN >> 1) / cbBitsPerBlock] ^= 
                                    (BitArrayType)((BitArrayType)1 << (int)((lpN >> 1) % cbBitsPerBlock));
                        }
                    }
    
                    // xx = 0
                    lpXX = 0;
                    for (lpX = 2; lpX < SQRT(mpLimit / 2) + 1; lpX += 2)
                    {
                        lpXX += 4*lpX - 4;
                        lpN = 3*lpXX;
    
                        if (lpN > mpLimit)
                        {
                            lpMinY = ((SQRT(lpN - mpLimit) >> 2) << 2) - 1;
                            lpYY = lpMinY * lpMinY;
                            lpN -= lpYY;
                            lpS = 4*lpMinY + 4;
                        }
                        else
                        {
                            lpN -= 1;
                            lpS = 0;
                        }
    
                        for (lpDN = lpS; lpDN < 4 * lpX; lpDN += 8)
                        {
                            lpN -= lpDN;
                            if (lpN <= mpLimit && lpN % 12 == 11)
                                lpbOddPrime[(lpN>>1) / cbBitsPerBlock] ^= 
                                    (BitArrayType)((BitArrayType)1 << (int)((lpN>>1) % cbBitsPerBlock));
                        }
                    }
    
                    // # eliminate squares
                    for (lpN = 5; lpN < SQRT(mpLimit) + 1; lpN += 2)
                        if ((lpbOddPrime[(lpN >> 1) / cbBitsPerBlock] & ((BitArrayType)1 << (int)((lpN >> 1) % cbBitsPerBlock))) != 0)
                            for (lpK = lpN * lpN; lpK < mpLimit; lpK += lpN * lpN)
                                if ((lpK & 1) == 1)
                                    lpbOddPrime[(lpK >> 1) / cbBitsPerBlock] &=
                                        (BitArrayType)~((BitArrayType)1 << (int)((lpK >> 1) % cbBitsPerBlock));
                }
            }
    
            /// <summary>
            /// Calculates the truncated square root for a number.
            /// </summary>
            /// <param name="value">The value to get the square root for.</param>
            /// <returns>The truncated sqrt of the value.</returns>
            private unsafe PrimeType SQRT(PrimeType value)
            {
                return (PrimeType)Math.Sqrt(value);
            }
    
            /// <summary>
            /// Gets a bit value by index.
            /// </summary>
            /// <param name="bits">The blocks containing the bits.</param>
            /// <param name="index">The index of the bit.</param>
            /// <returns>True if bit is set, false if cleared.</returns>
            private bool GetBitSafe(BitArrayType[] bits, PrimeType index)
            {
                if ((index & 1) == 1)
                    return (bits[(index >> 1) / cbBitsPerBlock] & ((BitArrayType)1 << (int)((index >> 1) % cbBitsPerBlock))) != 0;
                else
                    return false;
            }
    
            #endregion
    
            #region Public Properties
    
            /// <summary>
            /// Get the limit for the maximum prime value to find.
            /// </summary>
            public PrimeType Limit
            {
                get
                {
                    return mpLimit;
                }
            }
    
            /// <summary>
            /// Returns the number of primes found in the range.
            /// </summary>
            public PrimeType Count
            {
                get
                {
                    if (!mpCount.HasValue)
                    {
                        PrimeType lpCount = 0;
                        foreach (PrimeType liPrime in this) lpCount++;
                        mpCount = lpCount;
                    }
    
                    return mpCount.Value;
                }
            }
    
            /// <summary>
            /// Determines if a value in range is prime or not.
            /// </summary>
            /// <param name="test">The value to test for primality.</param>
            /// <returns>True if the value is prime, false otherwise.</returns>
            public bool this[PrimeType test]
            {
                get
                {
                    if (test > mpLimit) throw new ArgumentOutOfRangeException();
                    if (test <= 1) return false;
                    if (test == 2) return true;
                    if ((test & 1) == 0) return false;
                    return !GetBitSafe(mbaOddPrime, test >> 1);
                }
            }
    
            #endregion
    
            #region Public Methods
    
            /// <summary>
            /// Gets the enumerator for the primes.
            /// </summary>
            /// <returns>The enumerator of the primes.</returns>
            public IEnumerator<PrimeType> GetEnumerator()
            {
                //    return [2,3] + filter(primes.__getitem__, xrange(5,limit,2))
    
                // Two & Three always prime.
                yield return 2;
                yield return 3;
    
                // Start at first block, third MSB (5).
                int liBlock = 0;
                byte lbBit = 2;
                BitArrayType lbaCurrent = mbaOddPrime[0] >> lbBit;
    
                // For each value in range stepping in incrments of two for odd values.
                for (PrimeType lpN = 5; lpN <= mpLimit; lpN += 2)
                {
                    // If current bit not set then value is prime.
                    if ((lbaCurrent & 1) == 1)
                        yield return lpN;
    
                    // Move to NSB.
                    lbaCurrent >>= 1;
    
                    // Increment bit value. 
                    lbBit++;
    
                    // If block is finished.
                    if (lbBit == cbBitsPerBlock) 
                    {
                        lbBit = 0;
                        lbaCurrent = mbaOddPrime[++liBlock];
    
                        //// Move to first bit of next block skipping full blocks.
                        while (lbaCurrent == 0)
                        {
                            lpN += ((PrimeType)cbBitsPerBlock) << 1;
                            if (lpN <= mpLimit)
                                lbaCurrent = mbaOddPrime[++liBlock];
                            else
                                break;
                        }
                    }
                }
            }
    
            #endregion
    
            #region IEnumerable<PrimeType> Implementation
    
            /// <summary>
            /// Gets the enumerator for the primes.
            /// </summary>
            /// <returns></returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
            #endregion
        }
    }
