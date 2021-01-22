    public struct MemoryStatus 
    { 
        public uint Length;  
        public uint MemoryLoad; 
        public uint TotalPhysical; 
        public uint AvailablePhysical; 
        public uint TotalPageFile; 
        public uint AvailablePageFile; 
        public uint TotalVirtual; 
        public uint AvailableVirtual; 
    } 
    
    [DllImport("kernel32.dll")] 
    public static extern void GlobalMemoryStatus(out MemoryStatus stat);
