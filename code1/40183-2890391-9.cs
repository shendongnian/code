    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    
    namespace Utils
    {
      public static class ProcessTree
      {
    
        public static List<Process> GetProcessDescendants(Process process)
        {
          List<Process> result = new List<Process>();
          foreach (Process eachProcess in Process.GetProcesses())
          {
            if (ParentPid(eachProcess) == process.Id)
            {
              result.Add(eachProcess);
            }
          }
          return result;
        }
    
        public static void KillDescendants(Process processToNotKillYet) 
        {
          foreach (Process eachProcess in Process.GetProcesses()) 
          {
            if (ParentPid(eachProcess) == processToNotKillYet.Id) 
            {
              if (eachProcess.Id != Process.GetCurrentProcess().Id)
                KillTree(eachProcess);
            }
          }
        }
    
        public static void KillTree(Process processToKill) 
        {
          KillDescendants(processToKill);
          processToKill.Kill();
        }
    
        public static PROCESS_BASIC_INFORMATION Info(Process process) 
        {
          PROCESS_BASIC_INFORMATION processInfo = new PROCESS_BASIC_INFORMATION();
          try
          {
            uint bytesWritten;
            NtQueryInformationProcess(process.Handle,
                            0,
                            ref processInfo,
                            (uint)Marshal.SizeOf(processInfo),
                            out bytesWritten); // == 0 is OK
          }
          catch (Win32Exception e) 
          {
            if (!e.Message.Equals("Access is denied")) throw;
          }
    
          return processInfo;
        }
    
        public static int ParentPid(Process process) 
        {
          return Info(process).ParentPid;
        }
    
        [DllImport("ntdll.dll")]
        private static extern int NtQueryInformationProcess(
          IntPtr hProcess,
          int processInformationClass /* 0 */,
          ref PROCESS_BASIC_INFORMATION processBasicInformation,
          uint processInformationLength,
          out uint returnLength);
    
        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_BASIC_INFORMATION 
        {
          public int ExitStatus;
          public int PebBaseAddress;
          public int AffinityMask;
          public int BasePriority;
          public int Pid;
          public int ParentPid;
        }
      }
    }
