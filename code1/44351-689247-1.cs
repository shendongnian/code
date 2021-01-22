    isWow64 = false;
    if (System.Environment.OSVersion.Version.Major >= 5 && 
         System.Environment.OSVersion.Version.Minor >= 1)
    {
         var processHandle = GetProcessHandle((uint)
              System.Diagnostics.Process.GetCurrentProcess().Id);
         bool retVal;
         if (!NativeMethods.IsWow64Process(processHandle, out retVal))
         {
         throw (new Win32Exception());
         }
         isWow64 = retVal;
    }
