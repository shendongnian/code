    [DllImport("the_name_of_the_delphi_library.dll")]
    public static extern string CPUFamily();
    
    [DllImport("the_name_of_the_delphi_library.dll")]
    public static extern int GetCpuTheoreticSpeed();
    
    [DllImport("the_name_of_the_delphi_library.dll")]
    public static extern bool IsCPUIDAvailable();
    
    [DllImport("the_name_of_the_delphi_library.dll")]
    public static extern string GetCPUID(byte cpuCore);
    
    [DllImport("the_name_of_the_delphi_library.dll")]
    public static extern string GetCPUVendor();
    
    [DllImport("the_name_of_the_delphi_library.dll")]
    public static extern uint MemoryStatus(int memType);
    
    [DllImport("the_name_of_the_delphi_library.dll")]
    public static extern string MemoryStatus_MB(int memType);
    
    [DllImport("the_name_of_the_delphi_library.dll")]
    public static extern string GetPartitionID(char partition);
    
    [DllImport("the_name_of_the_delphi_library.dll")]
    public static extern string GetIDESerialNumber(byte driveNumber);
