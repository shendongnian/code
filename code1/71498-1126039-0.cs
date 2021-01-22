    using System;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    static class myProcessEx
    {  
        //inner enum used only internally
        [Flags]
        private enum SnapshotFlags : uint
        {
        HeapList = 0x00000001,
        Process = 0x00000002,
        Thread = 0x00000004,
        Module = 0x00000008,
        Module32 = 0x00000010,
        Inherit = 0x80000000,
        All = 0x0000001F
        }
        //inner struct used only internally
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct PROCESSENTRY32
        {
        const int MAX_PATH = 260;
        internal UInt32 dwSize;
        internal UInt32 cntUsage;
        internal UInt32 th32ProcessID;
        internal IntPtr th32DefaultHeapID;
        internal UInt32 th32ModuleID;
        internal UInt32 cntThreads;
        internal UInt32 th32ParentProcessID;
        internal Int32 pcPriClassBase;
        internal UInt32 dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        internal string szExeFile;
        }
    
        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr CreateToolhelp32Snapshot([In]UInt32 dwFlags, [In]UInt32 th32ProcessID);
    
        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern bool Process32First([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);
    
        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern bool Process32Next([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);
    
        // get the parent process given a pid
        public static Process GetParentProcess(int pid)
        {
    
        Process parentProc = null;
        try
        {
            PROCESSENTRY32 procEntry = new PROCESSENTRY32();
            procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(PROCESSENTRY32));
            IntPtr handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.Process, 0);
            if (Process32First(handleToSnapshot, ref procEntry))
            {
            do
            {
                if (pid == procEntry.th32ProcessID)
                {
                parentProc = Process.GetProcessById((int)procEntry.th32ParentProcessID);
                break;
    
                }
            } while (Process32Next(handleToSnapshot, ref procEntry));
            }
            else
            {
            throw new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()));
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Can't get the process.", ex);
        }
        return parentProc;
        }
    
        // get the specific parent process
        public static Process CurrentParentProcess
        {
        get
        {
            return GetParentProcess(Process.GetCurrentProcess().Id);
        }
        }
    
        static void Main()
        {
        Process pr = CurrentParentProcess;
    
        Console.WriteLine("Parent Proc. ID: {0}, Parent Proc. name: {1}", pr.Id, pr.ProcessName);
        }
    }
