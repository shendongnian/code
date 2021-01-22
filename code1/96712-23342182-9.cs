    //Sieve of Eratosthenes based on maximum wheel factorization and pre-culling implementation...
    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace NonPagedSoE {
      //implements the non-paged Sieve of Eratosthenes (full modulo 210 version with preculling)...
      class SoE : IEnumerable<ulong> {
        private ushort[] buf = null;
        private long cnt = 0;
        private long opcnt = 0;
        private static byte[] basePRMS = { 2, 3, 5, 7, 11, 13, 17, 19 };
        private static byte[] modPRMS = { 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, //positions + 23
                                          97, 101, 103, 107, 109, 113, 121, 127, 131, 137, 139, 143, 149, 151, 157, 163,
                                          167, 169, 173, 179, 181 ,187 ,191 ,193, 197, 199, 209, 211, 221, 223, 227, 229 };
        private static byte[] gapsPRMS = { 6, 2, 6, 4, 2, 4, 6, 6, 2, 6, 4, 2, 6, 4, 6, 8,
                                           4, 2, 4, 2, 4, 8, 6, 4, 6, 2, 4, 6, 2, 6, 6, 4,
                                           2, 4, 6, 2, 6, 4, 2, 4, 2, 10, 2, 10, 2, 4, 2, 4 };
        private static ulong[] modLUT;
        private static byte[] cntLUT;
        //initialize the private LUT's...
        static SoE() {
          modLUT = new ulong[210];
          for (int i = 0, m = 0; i < modLUT.Length; ++i) {
            if ((i & 1) != 0 || (i + 23) % 3 == 0 || (i + 23) % 5 == 0 || (i + 23) % 7 == 0) modLUT[i] = 0;
            else modLUT[i] = 1UL << (m++);
          }
          cntLUT = new byte[65536];
          for (int i = 0; i < cntLUT.Length; ++i) {
            var c = 0;
            for (int j = i ^ 0xFFFF; j > 0; j >>= 1) c += j & 1; //reverse logic; 0 is prime; 1 is composite
            cntLUT[i] = (byte)c;
          }
        }
        //initialization and all the work producing the prime bit array done in the constructor...
        public SoE(ulong range) {
          this.opcnt = 0;
          if (range < 23) {
            if (range > 1) {
              for (int i = 0; i < modPRMS.Length; ++i) if (modPRMS[i] <= range) this.cnt++; else break;
            }
            this.buf = new ushort[0];
          }
          else {
            this.cnt = 8;
            var nrng = range - 23; var lmtw = nrng / 210; var lmtwt3 = lmtw * 3; 
            //initialize sufficient wheels to prime
            this.buf = new ushort[lmtwt3 + 3]; //initial state of all zero's is all potential prime.
            //initialize array to account for preculling the primes of 11, 13, 17, and 19;
            //(2, 3, 5, and 7 already eliminated by the bit packing to residues).
            for (int pn = modPRMS.Length - 4; pn < modPRMS.Length; ++pn) {
              uint p = modPRMS[pn] - 210u; ulong pt3 = p * 3;
              ulong s = p * p - 23;
              ulong xrng = Math.Min(9699709, nrng); // only do for the repeating master pattern size
              ulong nwrds = (ulong)Math.Min(138567, this.buf.Length);
              for (int j = 0; s <= xrng && j < modPRMS.Length; s += p * gapsPRMS[(pn + j++) % 48]) {
                var sm = modLUT[s % 210];
                var si = (sm < (1UL << 16)) ? 0UL : ((sm < (1UL << 32)) ? 1UL : 2UL);
                var cd = s / 210 * 3 + si; var cm = (ushort)(sm >> (int)(si << 4));
                for (ulong c = cd; c < nwrds; c += pt3) { //tight culling loop for size of master pattern
                  this.buf[c] |= cm; // ++this.opcnt; //reverse logic; mark composites with ones.
                }
              }
            }
            //Now copy the master pattern so it repeats across the main buffer, allow for overflow...
            for (long i = 138567; i < this.buf.Length; i += 138567)
              if (i + 138567 <= this.buf.Length)
                Array.Copy(this.buf, 0, this.buf, i, 138567);
              else Array.Copy(this.buf, 0, this.buf, i, this.buf.Length - i);
            //Eliminate all composites which are factors of base primes, only for those on the wheel:
            for (uint i = 0, w = 0, wi = 0, pd = 0, pn = 0, msk = 1; w < this.buf.Length; ++i) {
              uint p = pd + modPRMS[pn];
              ulong sqr = (ulong)p * (ulong)p;
              if (sqr > range) break;
              if ((this.buf[w] & msk) == 0) { //found base prime, mark its composites...
                ulong s = sqr - 23; ulong pt3 = p * 3;
                for (int j = 0; s <= nrng && j < modPRMS.Length; s += p * gapsPRMS[(pn + j++) % 48]) {
                  var sm = modLUT[s % 210];
                  var si = (sm < (1UL << 16)) ? 0UL : ((sm < (1UL << 32)) ? 1UL : 2UL);
                  var cd = s / 210 * 3 + si; var cm = (ushort)(sm >> (int)(si << 4));
                  for (ulong c = cd; c < (ulong)this.buf.Length; c += pt3) { //tight culling loop
                    this.buf[c] |= cm; // ++this.opcnt; //reverse logic; mark composites with ones.
                  }
                }
              }
              ++pn;
              if (msk >= 0x8000) { msk = 1; ++w; ++wi; if (wi == 3) { wi = 0; pn = 0; pd += 210; } }
              else msk <<= 1;
            }
            //clear any overflow primes in the excess space in the last wheel/word:
            var ndx = nrng % 210; //clear any primes beyond the range
            for (; modLUT[ndx] == 0; --ndx) ;
            var cmsk = (~(modLUT[ndx] - 1)) << 1; //force all bits above to be composite ones.
            this.buf[lmtwt3++] |= (ushort)cmsk;
            this.buf[lmtwt3++] |= (ushort)(cmsk >> 16);
            this.buf[lmtwt3] |= (ushort)(cmsk >> 32);
          }
        }
        //uses a fast pop count Look Up Table to return the total number of primes...
        public long Count {
          get {
            long cnt = this.cnt;
            for (int i = 0; i < this.buf.Length; ++i) cnt += cntLUT[this.buf[i]];
            return cnt;
          }
        }
        //returns the number of cull operations used to sieve the prime bit array...
        public long Ops {
          get {
            return this.opcnt;
          }
        }
        //generate the enumeration of primes...
        public IEnumerator<ulong> GetEnumerator() {
          yield return 2; yield return 3; yield return 5; yield return 7;
          yield return 11; yield return 13; yield return 17; yield return 19;
          ulong pd = 0;
          for (uint i = 0, w = 0, wi = 0, pn = 0, msk = 1; w < this.buf.Length; ++i) {
            if ((this.buf[w] & msk) == 0) //found a prime bit...
              yield return pd + modPRMS[pn];
            ++pn;
            if (msk >= 0x8000) { msk = 1; ++w; ++wi; if (wi == 3) { wi = 0; pn = 0; pd += 210; } }
            else msk <<= 1;
          }
        }
        //required for the above enumeration...
        IEnumerator IEnumerable.GetEnumerator() {
          return this.GetEnumerator();
        }
      }
      class Program {
        static void Main(string[] args) {
          Console.WriteLine("This program calculates primes by a simple maximually wheel factorized version of the Sieve of Eratosthenes.\r\n");
          const ulong n = 1000000000;
          var elpsd = -DateTime.Now.Ticks;
          var gen = new SoE(n);
          elpsd += DateTime.Now.Ticks;
          Console.WriteLine("{0} primes found to {1} using {2} operations in {3} milliseconds.", gen.Count, n, gen.Ops, elpsd / 10000);
    //      Console.WriteLine();
    //      foreach (var p in gen) {
    //        Console.Write(p + " ");
    //      }
    //      Console.WriteLine();
          //      Console.WriteLine("\r\nThere are {0} primes with the last one {1} and the sum {2}.",gen.Count(),gen.Last(),gen.Sum(x => (long)x));
          Console.Write("\r\nPress any key to exit:");
          Console.ReadKey(true);
          Console.WriteLine();
        }
      }
    }
