    namespace RamMonitorPrototype
    {
    
    
        // https://stackoverflow.com/a/55202696/155077
        //[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        //unsafe internal struct Utsname_internal
        //{
        //    public fixed byte sysname[65];
        //    public fixed byte nodename[65];
        //    public fixed byte release[65];
        //    public fixed byte version[65];
        //    public fixed byte machine[65];
        //    public fixed byte domainname[65];
        //}
    
    
        public class Utsname
        {
            public string SysName; // char[65]
            public string NodeName; // char[65]
            public string Release; // char[65]
            public string Version; // char[65]
            public string Machine; // char[65]
            public string DomainName; // char[65]
    
            public void Print()
            {
                System.Console.Write("SysName:\t");
                System.Console.WriteLine(this.SysName); // Linux 
    
                System.Console.Write("NodeName:\t");
                System.Console.WriteLine(this.NodeName); // System.Environment.MachineName
    
                System.Console.Write("Release:\t");
                System.Console.WriteLine(this.Release); // Kernel-version
    
                System.Console.Write("Version:\t");
                System.Console.WriteLine(this.Version); // #40~18.04.1-Ubuntu SMP Thu Nov 14 12:06:39 UTC 2019
    
                System.Console.Write("Machine:\t");
                System.Console.WriteLine(this.Machine); // x86_64
    
                System.Console.Write("DomainName:\t");
                System.Console.WriteLine(this.DomainName); // (none)
            }
    
    
        }
    
    
        // https://github.com/microsoft/referencesource/blob/master/System/compmod/microsoft/win32/UnsafeNativeMethods.cs
        // https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Environment.Windows.cs
        public class DetermineOsBitness
        {
            private const string Kernel32 = "kernel32.dll";
    
    
    
            [System.Runtime.InteropServices.DllImport("libc", EntryPoint = "uname", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
            private static extern int uname_syscall(System.IntPtr buf);
    
            // https://github.com/jpobst/Pinta/blob/master/Pinta.Core/Managers/SystemManager.cs
            public static Utsname Uname()
            {
                Utsname uts = null;
                System.IntPtr buf = System.IntPtr.Zero;
    
                buf = System.Runtime.InteropServices.Marshal.AllocHGlobal(8192);
                // This is a hacktastic way of getting sysname from uname ()
                if (uname_syscall(buf) == 0)
                {
                    uts = new Utsname();
                    uts.SysName = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(buf);
    
                    long bufVal = buf.ToInt64();
                    uts.NodeName = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(new System.IntPtr(bufVal + 1 * 65));
                    uts.Release = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(new System.IntPtr(bufVal + 2 * 65));
                    uts.Version = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(new System.IntPtr(bufVal + 3 * 65));
                    uts.Machine = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(new System.IntPtr(bufVal + 4 * 65));
                    uts.DomainName = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(new System.IntPtr(bufVal + 5 * 65));
    
                    if (buf != System.IntPtr.Zero)
                        System.Runtime.InteropServices.Marshal.FreeHGlobal(buf);
                } // End if (uname_syscall(buf) == 0) 
    
                return uts;
            } // End Function Uname
    
    
    
            [System.Runtime.InteropServices.DllImport(Kernel32, CharSet = System.Runtime.InteropServices.CharSet.Auto, BestFitMapping = false)]
            [System.Runtime.Versioning.ResourceExposure(System.Runtime.Versioning.ResourceScope.Machine)]
            private static extern System.IntPtr GetModuleHandle(string modName);
    
    
            [System.Runtime.InteropServices.DllImport(Kernel32, CharSet = System.Runtime.InteropServices.CharSet.Ansi, BestFitMapping = false, SetLastError = true, ExactSpelling = true)]
            [System.Runtime.Versioning.ResourceExposure(System.Runtime.Versioning.ResourceScope.None)]
            private static extern System.IntPtr GetProcAddress(System.IntPtr hModule, string methodName);
    
    
            [System.Runtime.InteropServices.DllImport(Kernel32, SetLastError = true, CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
            [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            private static extern bool IsWow64Process(
                 [System.Runtime.InteropServices.In] Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid hProcess,
                 [System.Runtime.InteropServices.Out, System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)] out bool wow64Process
            );
    
    
            [System.Security.SecurityCritical]
            private static bool DoesWin32MethodExist(string moduleName, string methodName)
            {
                System.IntPtr hModule = GetModuleHandle(moduleName);
    
                if (hModule == System.IntPtr.Zero)
                {
                    System.Diagnostics.Debug.Assert(hModule != System.IntPtr.Zero, "GetModuleHandle failed.  Dll isn't loaded?");
                    return false;
                }
    
                System.IntPtr functionPointer = GetProcAddress(hModule, methodName);
                return (functionPointer != System.IntPtr.Zero);
            }
    
            public static bool Is64BitOperatingSystem()
            {
                if (System.IntPtr.Size * 8 == 64)
                    return true;
    
                if (!DoesWin32MethodExist(Kernel32, "IsWow64Process"))
                    return false;
                bool isWow64;
                using(Microsoft.Win32.SafeHandles.SafeWaitHandle safeHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(System.Diagnostics.Process.GetCurrentProcess().Handle, true))
                {
                    IsWow64Process(safeHandle, out isWow64);
                }
                return isWow64;
            }
    
            // This doesn't work reliably
            public static string GetProcessorArchitecture()
            {
                string strProcessorArchitecture = null;
    
                try
                {
                    strProcessorArchitecture = System.Convert.ToString(System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
    
                    switch (typeof(string).Assembly.GetName().ProcessorArchitecture)
                    {
                        case System.Reflection.ProcessorArchitecture.X86:
                            strProcessorArchitecture = "x86";
                            break;
                        case System.Reflection.ProcessorArchitecture.Amd64:
                            strProcessorArchitecture = "x86";
                            break;
                        case System.Reflection.ProcessorArchitecture.Arm:
                            strProcessorArchitecture = "ARM";
                            break;
                    }
    
                    bool is64bit = !string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));
    
                    if (is64bit)
                        strProcessorArchitecture += "-64";
                    else
                        strProcessorArchitecture += "-32";
                }
                catch (System.Exception ex)
                {
                    strProcessorArchitecture = ex.Message;
                }
    
                return strProcessorArchitecture;
            } // End Function GetProcessorArchitecture
    
    
        }
    
    
    }
