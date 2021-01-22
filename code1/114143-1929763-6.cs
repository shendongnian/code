        [StructLayout(LayoutKind.Sequential, Size=512)]
        internal struct HeaderBlock
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
            public byte[]   name;    // name of file. 
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[]   mode;    // file mode
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[]   uid;     // owner user ID
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[]   gid;     // owner group ID
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public byte[]   size;    // length of file in bytes
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public byte[]   mtime;   // modify time of file
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[]   chksum;  // checksum for header
    
            // ... more like that... up to 512 bytes. 
