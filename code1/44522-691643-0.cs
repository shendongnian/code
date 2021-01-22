    [StructLayout(LayoutKind.Sequential)]
    struct SafeArray
    {
        public ushort   dimensions;  
        public ushort   features;    
        public uint     elementSize; 
        public uint     locks;       
        public IntPtr   dataPtr;     
        public uint     elementCount;
        public int      lowerBound;  
    }
