        private const string MYDLL = @"my.dll";
        [DllImport(MYDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int DataBlockDownload([MarshalAs(UnmanagedType.U4)] int A, [MarshalAs(UnmanagedType.LPArray, SizeConst = 2048)] byte[] B, [MarshalAs(UnmanagedType.U4)] int C);
        // NOTE: The data block byte array is fixed at 2Kbyte long!!
    public delegate int DDataBlockCallback([MarshalAs(UnmanagedType.U4)] int A, [MarshalAs(UnmanagedType.LPArray, SizeConst = 2048)] byte[] B, [MarshalAs(UnmanagedType.U4)] int C);
