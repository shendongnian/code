        [StructLayout(LayoutKind.Sequential)]        
        public struct TidyBuffer        
        {
            public IntPtr allocator;  // Pointer to custom allocator            
            public IntPtr bp;         // Pointer to bytes            
            public uint size;         // # bytes currently in use            
            public uint allocated;    // # bytes allocated            
            public uint next;         // Offset of current input position        
        };        
