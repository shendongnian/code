    //Sieve of Eratosthenes based on full non page segmented modulo 210 with pre-culling to 19...
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    namespace NonPagedSoE {
      //implements the non-paged Sieve of Eratosthenes (full wheel factorization version)...
      class SoE : IEnumerable<ulong> {
        private ushort[] buf = null;
        private long cnt = 0;
        private long opcnt = 0;
        private static byte[] whlPRMS = { 2, 3, 5, 7, 11, 13, 17, 19 };
        private static byte[] modPRMS = { 23,29,31,37,41,43,47,53, 59,61,67,71,73,79,83, //positions + 23
                                          89,97,101,103,107,109,113,121,127, 131,137,139,143,149,151,157,163,
                                          167,169,173,179,181,187,191,193, 197,199,209,211,221,223,227,229, 233 };
        private static byte[] modLUT; //modulo for corresponding bit position.
        private static byte[] cntLUT; //fast counting pop count Look Up Table
        private static ushort[] mstrPTRN; // master Pattern of preculled composites
        //initialize the private LUT's and master Pattern of preculled composites...
        static SoE() {
          modLUT = new byte[210]; //modulo for corresponding bit position, built so it will round down
          for (int i = 0, m = -1; i < modLUT.Length; ++i) {
            if ((i & 1) != 0 || (i + 23) % 3 == 0 || (i + 23) % 5 == 0 || (i + 23) % 7 == 0) modLUT[i] = (byte)m;
            else modLUT[i] = (byte)++m;
          }
          cntLUT = new byte[65536]; //fast counting pop count Look Up Table
          for (int i = 0; i < cntLUT.Length; ++i) {
            var c = 0;
            for (int j = i; j > 0; j >>= 1) c += j & 1;
            cntLUT[i] = (byte)c;
          }
          mstrPTRN = new ushort[138567];
          for (int i = 0; i < mstrPTRN.Length; ++i)  mstrPTRN[i] = 0xFFFF; //start marked all prime
          int pi = 48 - 4; //the current prime hit index...
          foreach (var p in whlPRMS.SkipWhile(p => p <= 7)) { //not so effieicnt SoE just for initialization of pattern
            for (int c = p * p - 23, wi = pi; c < mstrPTRN.Length * 70; c += p * (- modPRMS[wi++] + modPRMS[wi]),
                                                                        wi = (wi > 47) ? 0 : wi) {
              var cn = modLUT[c % 210]; mstrPTRN[c / 210 * 3 + (cn >> 4)] &= (ushort)((1 << (cn & 15)) ^ 0xFFFF);
            }
            ++pi;
          }
        }
        //initialization and all the work producing the prime bit array done in the constructor...
        public SoE(ulong range) {
          this.opcnt = 0;
          if (range < 23) {
            this.cnt = whlPRMS.TakeWhile(p => p <= range).Count();
            this.buf = new ushort[0];
          }
          else {
            this.cnt = whlPRMS.Count();
            var nrng = range - 23; var lmtw = (nrng / 210 + 1) * 3 - 1; //even number of 48 hit/bit wheels
            //initialize sufficient wheels...
            this.buf = new ushort[lmtw + 1];
            //fill the sieve array with the master pattern
            for (int i = 0; i < this.buf.Length; i += mstrPTRN.Length)
              Array.Copy(mstrPTRN, 0, this.buf, i,
                         (i + mstrPTRN.Length > this.buf.Length) ? this.buf.Length - i : mstrPTRN.Length);
            //Eliminate multiples of base primes, only for those on the wheel:
            for (uint w = 0, pd = 0, pn = 0, msk = 1; w < this.buf.Length; ) {
              uint p = pd + modPRMS[pn];
              uint sqr = p * p;
              if (sqr > range) break;
              if ((this.buf[w] & msk) != 0) { //found base prime, cull it...
                uint s = sqr - 23; var p3 = p * 3;
                for (uint j = 0, wi = pn; s <= nrng && j < 48; s += p * (uint)(- modPRMS[wi++] + modPRMS[wi]),
                                                               wi = (wi > 47) ? 0 : wi, ++j) {
                  var cn = modLUT[s % 210]; var cm = (ushort)((1 << (cn & 15)) ^ 0xFFFF); 
                  //may need ulong loop index for ranges larger than two billion
                  //but buf length only good to about 2^31 * 210 = 400 billion anyway,
                  //even with large array setting and half that with 32-bit...
                  for (uint c = s / 210 * 3 + (uint)(cn >> 4); c < this.buf.Length; c += p3) {
                    this.buf[c] &= cm; // ++this.opcnt;
                  }
                }
              }
              if (msk >= 0x8000) { msk = 1; ++w; if (pn > 31) { pn = 0; pd += 210; } else ++pn; }
              else { msk <<= 1; ++pn; }
            }
            //clear any overflow primes in the excess space in the last wheel:
            var ndx = nrng % 210; //clear any primes beyond the range
            ulong mc = ((ulong)1 << (modLUT[ndx] + 1)) - 1;
            this.buf[lmtw - 2] &= (ushort)mc;
            this.buf[lmtw - 1] &= (ushort)(mc >> 16);
            this.buf[lmtw] &= (ushort)(mc >> 32);
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
        //returns the number of toggle/cull operations used to sieve the prime bit array...
        public long Ops {
          get {
            return this.opcnt;
          }
        }
        //generate the enumeration of primes...
        public IEnumerator<ulong> GetEnumerator() {
          foreach (var p in whlPRMS) yield return p;
          ulong pd = 0;
          for (uint w = 0, pn = 0, msk = 1; w < this.buf.Length; ) {
            if ((this.buf[w] & msk) != 0) //found a prime bit...
              yield return pd + modPRMS[pn]; //add it to the list
            if (msk >= 0x8000) { msk = 1; ++w; if (pn > 31) { pn = 0; pd += 210; } else ++pn; }
            else { msk <<= 1; ++pn; }
          }
        }
        //required for the above enumeration...
        IEnumerator IEnumerable.GetEnumerator() {
          return this.GetEnumerator();
        }
      }
      class Program {
        static void Main(string[] args) {
          Console.WriteLine("This program calculates primes by a simple fully wheel factorized Sieve of Eratosthenes.\r\n");
          const ulong n = 1000000000;
          var elpsd = -DateTime.Now.Ticks;
          var gen = new SoE(n);
          elpsd += DateTime.Now.Ticks;
          Console.WriteLine("{0} primes found to {1} using {2} operations in {3} milliseconds.", gen.Count, n, gen.Ops, elpsd / 10000);
          //Console.WriteLine();
          //foreach (var p in gen) {
          //  Console.Write(p + " ");
          //}
          //Console.WriteLine();
          //      Console.WriteLine("\r\nThere are {0} primes with the last one {1} and the sum {2}.",gen.Count(),gen.Last(),gen.Sum(x => (long)x));
          Console.Write("\r\nPress any key to exit:");
          Console.ReadKey(true);
          Console.WriteLine();
        }
      }
    }
