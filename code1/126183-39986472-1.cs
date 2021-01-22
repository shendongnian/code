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
    /// <summary>Checks whether a process is being debugged.</summary>
    /// <remarks>
    /// The "remote" in CheckRemoteDebuggerPresent does not imply that the debugger
    /// necessarily resides on a different computer; instead, it indicates that the 
    /// debugger resides in a separate and parallel process.
    /// <para/>
    /// Use the IsDebuggerPresent function to detect whether the calling process 
    /// is running under the debugger.
    /// </remarks>
    [DllImport("Kernel32.dll", SetLastError=true, ExactSpelling=true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool CheckRemoteDebuggerPresent(
        SafeHandle hProcess,
        [MarshalAs(UnmanagedType.Bool)] ref bool isDebuggerPresent);
