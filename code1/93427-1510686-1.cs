    [StructLayout(LayoutKind.Sequential)]
    public struct ResultData
    {
        public uint uint1;
        public uint uint2;
        public Result result;
        public IntPtr RawResults;
        public Result Results { get { return (Result)Marshal.PtrToStructure(RawResults,typeof(Result)); }
    } 
