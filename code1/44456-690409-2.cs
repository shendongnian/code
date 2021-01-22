    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct tPacket {
        
        /// WORD->unsigned short
        public ushort word1;
        
        /// WORD->unsigned short
        public ushort word2;
        
        /// BYTE->unsigned char
        public byte byte1;
        
        /// BYTE->unsigned char
        public byte byte2;
        
        /// BYTE[8]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=8, ArraySubType=System.Runtime.InteropServices.UnmanagedType.I1)]
        public byte[] array123;
    }
