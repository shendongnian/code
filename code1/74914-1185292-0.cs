    [StructLayout(LayoutKind.Explicit)]
    unsafe struct OuterType
    {
        private const int BUFFER_SIZE = 100;
    
        [FieldOffset(0)]
        private int transactionType;
    
        [FieldOffset(0), MarshalAs(UnmanagedType.ByValArray, SizeConst = BUFFER_SIZE)]
        private byte[] writeBuffer;
    
        public int TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }
    
        public char[] WriteBuffer
        {
            set { writeBuffer = value.Cast<byte>().ToArray(); }
            get { return writeBuffer.Cast<char>().ToArray(); }
        }
    }
