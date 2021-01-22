    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Diagnostics;
    namespace PowerControl
    {
        public class PowerControl_Main
        {
            public void Shutdown()
            {
                ManagementBaseObject mboShutdown = null;
                ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
                mcWin32.Get();
                if (!TokenAdjuster.EnablePrivilege("SeShutdownPrivilege", true))
                {
                    Console.WriteLine("Could not enable SeShutdownPrivilege");
                }
                else
                {
                    Console.WriteLine("Enabled SeShutdownPrivilege");
                }
                // You can't shutdown without security privileges
                mcWin32.Scope.Options.EnablePrivileges = true;
                ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");
                // Flag 1 means we want to shut down the system
                mboShutdownParams["Flags"] = "1";
                mboShutdownParams["Reserved"] = "0";
                foreach (ManagementObject manObj in mcWin32.GetInstances())
                {
                    try
                    {
                        mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                                       mboShutdownParams, null);
                    }
                    catch (ManagementException mex)
                    {
                        Console.WriteLine(mex.ToString());
                        Console.ReadKey();
                    }
                }
            }
        }
        public sealed class TokenAdjuster
        {
            // PInvoke stuff required to set/enable security privileges
            [DllImport("advapi32", SetLastError = true),
            SuppressUnmanagedCodeSecurityAttribute]
            static extern int OpenProcessToken(
            System.IntPtr ProcessHandle, // handle to process
            int DesiredAccess, // desired access to process
            ref IntPtr TokenHandle // handle to open access token
            );
            [DllImport("kernel32", SetLastError = true),
            SuppressUnmanagedCodeSecurityAttribute]
            static extern bool CloseHandle(IntPtr handle);
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern int AdjustTokenPrivileges(
            IntPtr TokenHandle,
            int DisableAllPrivileges,
            IntPtr NewState,
            int BufferLength,
            IntPtr PreviousState,
            ref int ReturnLength);
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern bool LookupPrivilegeValue(
            string lpSystemName,
            string lpName,
            ref LUID lpLuid);
            [StructLayout(LayoutKind.Sequential)]
            internal struct LUID
            {
                internal int LowPart;
                internal int HighPart;
            }
            [StructLayout(LayoutKind.Sequential)]
            struct LUID_AND_ATTRIBUTES
            {
                LUID Luid;
                int Attributes;
            }
            [StructLayout(LayoutKind.Sequential)]
            struct _PRIVILEGE_SET
            {
                int PrivilegeCount;
                int Control;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] // ANYSIZE_ARRAY = 1
                LUID_AND_ATTRIBUTES[] Privileges;
            }
            [StructLayout(LayoutKind.Sequential)]
            internal struct TOKEN_PRIVILEGES
            {
                internal int PrivilegeCount;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
                internal int[] Privileges;
            }
            const int SE_PRIVILEGE_ENABLED = 0x00000002;
            const int TOKEN_ADJUST_PRIVILEGES = 0X00000020;
            const int TOKEN_QUERY = 0X00000008;
            const int TOKEN_ALL_ACCESS = 0X001f01ff;
            const int PROCESS_QUERY_INFORMATION = 0X00000400;
            public static bool EnablePrivilege(string lpszPrivilege, bool
            bEnablePrivilege)
            {
                bool retval = false;
                int ltkpOld = 0;
                IntPtr hToken = IntPtr.Zero;
                TOKEN_PRIVILEGES tkp = new TOKEN_PRIVILEGES();
                tkp.Privileges = new int[3];
                TOKEN_PRIVILEGES tkpOld = new TOKEN_PRIVILEGES();
                tkpOld.Privileges = new int[3];
                LUID tLUID = new LUID();
                tkp.PrivilegeCount = 1;
                if (bEnablePrivilege)
                    tkp.Privileges[2] = SE_PRIVILEGE_ENABLED;
                else
                    tkp.Privileges[2] = 0;
                if (LookupPrivilegeValue(null, lpszPrivilege, ref tLUID))
                {
                    Process proc = Process.GetCurrentProcess();
                    if (proc.Handle != IntPtr.Zero)
                    {
                        if (OpenProcessToken(proc.Handle, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY,
                        ref hToken) != 0)
                        {
                            tkp.PrivilegeCount = 1;
                            tkp.Privileges[2] = SE_PRIVILEGE_ENABLED;
                            tkp.Privileges[1] = tLUID.HighPart;
                            tkp.Privileges[0] = tLUID.LowPart;
                            const int bufLength = 256;
                            IntPtr tu = Marshal.AllocHGlobal(bufLength);
                            Marshal.StructureToPtr(tkp, tu, true);
                            if (AdjustTokenPrivileges(hToken, 0, tu, bufLength, IntPtr.Zero, ref ltkpOld) != 0)
                            {
                                // successful AdjustTokenPrivileges doesn't mean privilege could be changed
                                if (Marshal.GetLastWin32Error() == 0)
                                {
                                    retval = true; // Token changed
                                }
                            }
                            TOKEN_PRIVILEGES tokp = (TOKEN_PRIVILEGES)Marshal.PtrToStructure(tu,
                            typeof(TOKEN_PRIVILEGES));
                            Marshal.FreeHGlobal(tu);
                        }
                    }
                }
                if (hToken != IntPtr.Zero)
                {
                    CloseHandle(hToken);
                }
                return retval;
            }
        }
    }
