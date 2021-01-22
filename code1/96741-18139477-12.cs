    class fastprimesSoE : IEnumerable<uint>, IEnumerable {
      struct procspc { public Task tsk; public uint[] buf; }
      struct wst { public byte msk; public byte mlt; public byte xtr; public byte nxt; }
      static readonly uint NUMPROCS = (uint)Environment.ProcessorCount + 1u; const uint CHNKSZ = 1u;
      const uint L1CACHEPOW = 18u, L1CACHESZ = (1u << (int)L1CACHEPOW), PGSZ = L1CACHESZ >> 2; //for 16K in bytes...
      const uint BUFSZ = CHNKSZ * PGSZ; //number of uints even number of caches in chunk
      const uint BUFSZBTS = 15u * BUFSZ << 2; //even in wheel rotations and uints (and chunks)
      static readonly byte[] WHLPTRN = { 2, 1, 2, 1, 2, 3, 1, 3 }; //the 2,3,5 factorial wheel, (sum) 15 elements long
      static readonly byte[] WHLPOS = { 0, 2, 3, 5, 6, 8, 11, 12 }; //get wheel position from index
      static readonly byte[] WHLNDX = { 0, 0, 1, 2, 2, 3, 4, 4, 5, 5, 5, 6, 7, 7, 7, //get index from position
                                        0, 0, 1, 2, 2, 3, 4, 4, 5, 5, 5, 6, 7 }; //allow for overflow
      static readonly byte[] WHLRNDUP = { 0, 2, 2, 3, 5, 5, 6, 8, 8, 11, 11, 11, 12, 15, //allow for overflow...
                                          15, 15, 17, 17, 18, 20, 20, 21, 23, 23, 26, 26, 26, 27 }; //round multiplier up
      const uint BPLMT = (ushort.MaxValue - 7u) / 2u; const uint BPSZ = BPLMT / 60u + 1u;
      static readonly uint[] bpbuf = new uint[BPSZ]; static readonly wst[] WHLST = new wst[64];
      static void cullpg(uint i, uint[] b, int strt, int cnt) { Array.Clear(b,strt,cnt);
        for (uint j = 0u, bw = 0x31321212u, bi = 0u, v = 0xc0881000u, bm = 1u; j <= BPLMT;
              j += bw & 0xF, bw = (bw > 3u) ? bw >>= 4 : 0x31321212u) { if ((v & bm) == 0u) {
            var p = 7u + j + j; var k = p * (j + 3u) + j; if (k >= i + cnt * 60) break; var pp = j % 15u; if (k < i) {
              k=(i-k)%(15u*p); if (k!=0) { var sw=pp+((k+p-1u)/p); sw=WHLRNDUP[sw]; k=(sw-pp)*p-k; } }
            else k -= i; var pd = p / 15;
            for (uint l=k/15u+(uint)strt*4u, lw=((uint)WHLNDX[pp]<<3) + WHLNDX[k%15]; l<(uint)(strt+cnt)*4u; ) {
              var st=WHLST[lw]; b[l>>2]|=(uint)st.msk<<(int)((l&3)<<3); l+=st.mlt*pd+st.xtr; lw=st.nxt; } }
          if ((bm << 1) == 0u) { v = bpbuf[++bi]; bm = 1u; } } }
      static fastprimesSoE() { for (var x= 0; x<8; ++x) { var p=7+2*WHLPOS[x]; var i=((p*p-7)/2)%15; p %= 15;
          for (var y = 0; y < 8; ++y) { var n=WHLNDX[i]; var m=WHLPTRN[(x+y)%8]; var pls=i+m*p; i=pls%15;
            WHLST[x*8+n] = new wst { msk=(byte)(1<<n), mlt=m, xtr=(byte)(pls/15), nxt=(byte)(8*x+WHLNDX[i]) }; } }
        cullpg(0u, bpbuf, 0, bpbuf.Length); } //init baseprimes
      class nmrtr : IEnumerator<uint>, IEnumerator, IDisposable { procspc[] ps = new procspc[NUMPROCS]; uint[] buf;
        Task dlycullpg(uint i, uint[] buf) { return Task.Factory.StartNew(() => {
          for (var c=0u; c<CHNKSZ; ++c) cullpg(i+c*PGSZ*60, buf, (int)(c*PGSZ), (int)PGSZ); }); }
        public nmrtr() { for (var i = 0u; i < NUMPROCS; ++i) ps[i] = new procspc { buf = new uint[BUFSZ] };
          for (var i=1u; i<NUMPROCS; ++i) { ps[i].tsk=dlycullpg((i-1u)*BUFSZBTS,ps[i].buf); } buf=ps[0].buf; }
          public uint Current { get { return this._curr; } } object IEnumerator.Current { get { return this._curr; } }
          uint _curr; int b = -4; uint i = 0, w = 0; uint v, msk = 0;
          public bool MoveNext() { if (b < 0) if (b == -1) { _curr = 7; b += (int)BUFSZ; }
              else { if (b++ == -4) this._curr = 2u; else this._curr = 7u + ((uint)b << 1); return true; }
            do { i += w & 0xF; if ((w >>= 4) == 0) w = 0x31321212u; if ((this.msk <<= 1) == 0) {
                if (++b>=BUFSZ) { b=0; for (var prc=0; prc<NUMPROCS-1; ++prc) ps[prc] = ps[prc+1]; ps[NUMPROCS-1u].buf=buf;
                  var low = i + (NUMPROCS - 1u) * BUFSZBTS;
                  ps[NUMPROCS - 1u].tsk = dlycullpg(i + (NUMPROCS - 1u) * BUFSZBTS, buf); ps[0].tsk.Wait(); buf = ps[0].buf;
                } v = buf[b]; this.msk = 1; } }
            while ((v & msk) != 0u); if (_curr > (_curr = 7u + i + i)) return false; else return true; }
          public void Reset() { throw new Exception("Primes enumeration reset not implemented!!!"); }
          public void Dispose() { } }
        public IEnumerator<uint> GetEnumerator() { return new nmrtr(); }
        IEnumerator IEnumerable.GetEnumerator() { return new nmrtr(); } }
