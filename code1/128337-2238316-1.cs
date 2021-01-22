    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processList = GetProcessesByPath(@"C:\Program Files\MyCalculator\calc.exe");
            foreach (var process in processList)
            {
                if (!process.HasExited)
                    process.Kill();
            }
        }
    
        static Process[] GetProcessesByPath(string path)
        {
            List<Process> result = new List<Process>();
    
            string processName = Path.GetFileNameWithoutExtension(path);
            foreach (var process in Process.GetProcessesByName(processName))
            {
                ToolHelpHandle hModuleSnap = NativeMethods.CreateToolhelp32Snapshot(NativeMethods.SnapshotFlags.Module, (uint)process.Id);
                if (!hModuleSnap.IsInvalid)
                {
                    NativeMethods.MODULEENTRY32 me32 = new NativeMethods.MODULEENTRY32();
                    me32.dwSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(me32);
                    if (NativeMethods.Module32First(hModuleSnap, ref me32))
                    {
                        if (me32.szExePath == path)
                        {
                            result.Add(process);
                        }
                    }
                    hModuleSnap.Close();
                }
            }
    
            return result.ToArray();
        }
    }
    
    //
    // The safe handle class is used to safely encapsulate win32 handles below
    //
    public class ToolHelpHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private ToolHelpHandle()
            : base(true)
        {
        }
    
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected override bool ReleaseHandle()
        {
            return NativeMethods.CloseHandle(handle);
        }
    }
    //
    // The following p/invoke wrappers are used to get the list of process and modules
    // running inside each process.
    //
    public class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static public extern bool CloseHandle(IntPtr hHandle);
    
        [DllImport("kernel32.dll")]
        static public extern bool Module32First(ToolHelpHandle hSnapshot, ref MODULEENTRY32 lpme);
    
        [DllImport("kernel32.dll")]
        static public extern bool Module32Next(ToolHelpHandle hSnapshot, ref MODULEENTRY32 lpme);
    
        [DllImport("kernel32.dll")]
        static public extern bool Process32First(ToolHelpHandle hSnapshot, ref PROCESSENTRY32 lppe);
    
        [DllImport("kernel32.dll")]
        static public extern bool Process32Next(ToolHelpHandle hSnapshot, ref PROCESSENTRY32 lppe);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        static public extern ToolHelpHandle CreateToolhelp32Snapshot(SnapshotFlags dwFlags, uint th32ProcessID);
    
        public const short INVALID_HANDLE_VALUE = -1;
    
        [Flags]
        public enum SnapshotFlags : uint
        {
            HeapList = 0x00000001,
            Process = 0x00000002,
            Thread = 0x00000004,
            Module = 0x00000008,
            Module32 = 0x00000010,
            Inherit = 0x80000000,
            All = 0x0000001F
        }
    
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct PROCESSENTRY32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        };
    
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct MODULEENTRY32
        {
            public uint dwSize;
            public uint th32ModuleID;
            public uint th32ProcessID;
            public uint GlblcntUsage;
            public uint ProccntUsage;
            IntPtr modBaseAddr;
            public uint modBaseSize;
            IntPtr hModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExePath;
        };
    }
