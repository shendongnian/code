    class C
    {
        private int z;
        public readonly Func<int, int> M = (int x)=>{ return x+z; }
        // ... and so on
    }
