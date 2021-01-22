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
        using PrimeType = System.UInt32;
    
        /// <summary>
        /// Calculates prime number using the Sieve of Eratosthenes method.
        /// </summary>
        /// <example>
        /// <code>
        ///     var lpPrimes = new Eratosthenes(1e7);
        ///     foreach (UInt32 luiPrime in lpPrimes)
        ///         Console.WriteLine(luiPrime);
        /// </example>
        public class Eratosthenes : IEnumerable<PrimeType>
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
            /// The current bit array where a set bit means
            /// the odd value at that location has been determined
            /// to not be prime.
            /// </summary>
            protected BitArrayType[] mbaOddNotPrime;
    
            #endregion
    
            #region Initialisation
    
            /// <summary>
            /// Create Sieve of Eratosthenes generator.
            /// </summary>
            /// <param name="limit">The limit for the maximum prime value to find.</param>
            public Eratosthenes(PrimeType limit)
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
                mbaOddNotPrime = new BitArrayType[(((mpLimit >> 1) + 1) / cbBitsPerBlock) + 1];
    
                // Cache Sqrt of limit.
                PrimeType lpSQRT = (PrimeType)Math.Sqrt(mpLimit);
    
                // Fix the bit array for pointer access
                fixed (BitArrayType* lpbOddNotPrime = &mbaOddNotPrime[0])
                    // Scan primes up to lpSQRT
                    for (PrimeType lpN = 3; lpN <= lpSQRT; lpN += 2)
                        // If the current bit value for index lpN is cleared (prime)
                        if (
                                (
                                    lpbOddNotPrime[(lpN >> 1) / cbBitsPerBlock] & 
                                    ((BitArrayType)1 << (BitsPerBlockType)((lpN >> 1) % cbBitsPerBlock))
                                ) == 0
                            )
                            // Leave it cleared (prime) and mark all multiples of lpN*2 from lpN*lpN as not prime
                            for (PrimeType lpM = lpN * lpN; lpM <= mpLimit; lpM += lpN << 1)
                                // Set as not prime
                                lpbOddNotPrime[(lpM >> 1) / cbBitsPerBlock] |= 
                                    (BitArrayType)((BitArrayType)1 << (BitsPerBlockType)((lpM >> 1) % cbBitsPerBlock));
            }
    
            /// <summary>
            /// Gets a bit value by index.
            /// </summary>
            /// <param name="bits">The blocks containing the bits.</param>
            /// <param name="index">The index of the bit.</param>
            /// <returns>True if bit is set, false if cleared.</returns>
            private bool GetBitSafe(BitArrayType[] bits, PrimeType index)
            {
                return (bits[index / cbBitsPerBlock] & ((BitArrayType)1 << (BitsPerBlockType)(index % cbBitsPerBlock))) != 0;
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
                    PrimeType lptCount = 0;
                    foreach (PrimeType liPrime in this)
                        lptCount++;
                    return lptCount;
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
                    return !GetBitSafe(mbaOddNotPrime, test >> 1);
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
                // Two always prime.
                yield return 2;
    
                // Start at first block, second MSB.
                int liBlock = 0;
                byte lbBit = 1;
                BitArrayType lbaCurrent = mbaOddNotPrime[0] >> 1;
    
                // For each value in range stepping in incrments of two for odd values.
                for (PrimeType lpN = 3; lpN <= mpLimit; lpN += 2)
                {
                    // If current bit not set then value is prime.
                    if ((lbaCurrent & 1) == 0)
                        yield return lpN;
    
                    // Move to NSB.
                    lbaCurrent >>= 1;
    
                    // Increment bit value.
                    lbBit++;
    
                    // If block is finished.
                    if (lbBit == cbBitsPerBlock) 
                    {
                        // Move to first bit of next block.
                        lbBit = 0;
                        liBlock++;
                        lbaCurrent = mbaOddNotPrime[liBlock];
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
