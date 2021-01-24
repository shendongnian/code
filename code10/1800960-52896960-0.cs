    using Microsoft.VisualBasic;
    public struct XY_DATA
    {
        [VBFixedArray(3)]
        public Single[] InData;
        [VBFixedArray(3)]
        public Single[] PrevData;
        [VBFixedArray(3)]
        public Single[] OutData;
        [VBFixedArray(3)]
        public Single[] ZeroData;
        [VBFixedArray(3)]
        public Single[] StatXY;
        [VBFixedArray(3)]
        public Single[] DynXY;
        [VBFixedArray(3)]
        public Single[] UnbXY;
        [VBFixedArray(3)]
        public Single[] StdDev;
        // Note: "Initialize" must be called to initialize instances of this structure. 
        public void Initialize()
        {
            InData = new Single[4];
            PrevData = new Single[4];
            OutData = new Single[4];
            ZeroData = new Single[4];
            StatXY = new Single[4];
            DynXY = new Single[4];
            UnbXY = new Single[4];
            StdDev = new Single[4];
        }
    }
