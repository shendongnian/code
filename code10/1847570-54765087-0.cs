    struct IO_COUNTERS {
    	public ulong ReadOperationCount;
    	public ulong WriteOperationCount;
    	public ulong OtherOperationCount;
    	public ulong ReadTransferCount;
    	public ulong WriteTransferCount;
    	public ulong OtherTransferCount;
    }
    
    ...
    [DllImport(@"kernel32.dll", SetLastError = true)]
    static extern bool GetProcessIoCounters(IntPtr hProcess, out IO_COUNTERS counters);
    
    ...
    
    if (GetProcessIoCounters(Process.GetCurrentProcess().Handle, out IO_COUNTERS counters)) {
    	Console.WriteLine(counters.ReadOperationCount);
        ...
