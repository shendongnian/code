    [StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct in_addr {
        
        /// Anonymous1
        public Anonymous1 S_un;
    }
    
    [StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Anonymous1 {
        
        /// Anonymous2
        [System.Runtime.InteropServices.FieldOffsetAttribute(0)]
        public Anonymous2 S_un_b;
        
        /// Anonymous3
        [System.Runtime.InteropServices.FieldOffsetAttribute(0)]
        public Anonymous3 S_un_w;
        
        /// u_long->unsigned int
        [System.Runtime.InteropServices.FieldOffsetAttribute(0)]
        public uint S_addr;
    }
    
    [StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct Anonymous2 {
        
        /// u_char->unsigned char
        public byte s_b1;
        
        /// u_char->unsigned char
        public byte s_b2;
        
        /// u_char->unsigned char
        public byte s_b3;
        
        /// u_char->unsigned char
        public byte s_b4;
    }
    
    [StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct Anonymous3 {
        
        /// u_short->unsigned short
        public ushort s_w1;
        
        /// u_short->unsigned short
        public ushort s_w2;
    }
