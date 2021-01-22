    namespace Is64Bit
    {
        using System;
        using System.ComponentModel;
        using System.Diagnostics;
        using System.Runtime.InteropServices;
    
        internal static class Program
        {
            private static void Main()
            {
                foreach (var p in Process.GetProcesses())
                {
                    try
                    {
                        Console.WriteLine(p.ProcessName + " is " + (p.IsWin64Emulator() ? string.Empty : "not ") + "32-bit");
                    }
                    catch (Win32Exception ex)
                    {
                        if (ex.NativeErrorCode != 0x00000005)
                        {
                            throw;
                        }
                    }
                }
    
                Console.ReadLine();
            }
    
            private static bool IsWin64Emulator(this Process process)
            {
                if ((Environment.OSVersion.Version.Major > 5)
                    || ((Environment.OSVersion.Version.Major == 5) && (Environment.OSVersion.Version.Minor >= 1)))
                {
                    bool retVal;
    
                    return NativeMethods.IsWow64Process(process.Handle, out retVal) && retVal;
                }
    
                return false; // not on 64-bit Windows Emulator
            }
        }
    
        internal static class NativeMethods
        {
            [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);
        }
    }
