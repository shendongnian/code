    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    namespace Util {
        public static class ProcessExtensions {
            public static void KillDescendants(this Process processToNotKillYet) {
                foreach (var eachProcess in Process.GetProcesses()) {
                    if (eachProcess.ParentPid() == processToNotKillYet.Id) {
                        eachProcess.KillTree();
                    }
                }
            }
            public static void KillTree(this Process processToKill) {
                processToKill.KillDescendants();
                processToKill.Kill();
            }
            public static PROCESS_BASIC_INFORMATION Info(this Process process) {
                var processInfo = new PROCESS_BASIC_INFORMATION();
                try {
                    uint bytesWritten;
                    NtQueryInformationProcess(process.Handle,
                                              0,
                                              ref processInfo,
                                              (uint)Marshal.SizeOf(processInfo),
                                              out bytesWritten); // == 0 is OK
                }
                catch (Win32Exception e) {
                    if (!e.Message.Equals("Access is denied")) throw;
                }
                return processInfo;
            }
            public static int ParentPid(this Process process) {
                return process.Info().ParentPid;
            }
            [DllImport("ntdll.dll")]
            private static extern int NtQueryInformationProcess(
                IntPtr hProcess,
                int processInformationClass /* 0 */,
                ref PROCESS_BASIC_INFORMATION processBasicInformation,
                uint processInformationLength,
                out uint returnLength);
            [StructLayout(LayoutKind.Sequential)]
            public struct PROCESS_BASIC_INFORMATION {
                public int ExitStatus;
                public int PebBaseAddress;
                public int AffinityMask;
                public int BasePriority;
                public int Pid;
                public int ParentPid;
            }
        }
    }
