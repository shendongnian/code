    static bool Is64BitProcess(IntPtr hProcess)
    {
        bool flag = false;
        if (Environment.Is64BitOperatingSystem)
        {
            // On 64-bit OS, if a process is not running under Wow64 mode, 
            // the process must be a 64-bit process.
            flag = !(NativeMethods.IsWow64Process(hProcess, out flag) && flag);
        }
 
        return flag;
    }
