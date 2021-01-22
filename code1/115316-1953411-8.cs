    namespace Is64Bit
    {
        using System;
        using System.Diagnostics;
        using System.Runtime.InteropServices;
    
        internal static class Program
        {
            private static void Main()
            {
                foreach (var p in Process.GetProcesses())
                {
                    Console.WriteLine(p.ProcessName + " is " + (IsWin64(p) ? string.Empty : "not ") + "32-bit");
                }
    
                Console.ReadLine();
            }
    
            private static bool IsWin64(Process process)
            {
                if ((Environment.OSVersion.Version.Major > 5)
                    || ((Environment.OSVersion.Version.Major == 5) && (Environment.OSVersion.Version.Minor >= 1)))
                {
                    IntPtr processHandle;
                    bool retVal;
    
                    try
                    {
                        processHandle = Process.GetProcessById(process.Id).Handle;
                    }
                    catch
                    {
                        return false; // access is denied to the process
                    }
    
                    return NativeMethods.IsWow64Process(processHandle, out retVal) && retVal;
                }
    
                return false; // not on 64-bit Windows
            }
        }
    
        internal static class NativeMethods
        {
            [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);
        }
    }
