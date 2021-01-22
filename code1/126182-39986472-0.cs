    Process process = ...;
    bool isDebuggerAttached;
    if (!CheckRemoteDebuggerPresent(process.Handle, out isDebuggerAttached)
    {
        // handle failure (throw / return / ...)
    }
    else
    {
        // use isDebuggerAttached
    }
    // with these native methods called via P/Invoke
    [DllImport("Kernel32.dll", SetLastError=true, ExactSpelling=true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool CheckRemoteDebuggerPresent(
        SafeHandle hProcess,
        [MarshalAs(UnmanagedType.Bool)] ref bool isDebuggerPresent);
