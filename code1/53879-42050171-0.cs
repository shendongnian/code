    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Diagnostics;
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool QueryFullProcessImageName([In]IntPtr hProcess, [In]int dwFlags, [Out]StringBuilder lpExeName, ref int lpdwSize);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr OpenProcess(
            UInt32 dwDesiredAccess,
            [MarshalAs(UnmanagedType.Bool)]
            Boolean bInheritHandle,
            Int32 dwProcessId
        );
    }
    public static class utils
    {
        private const UInt32 PROCESS_QUERY_INFORMATION = 0x400;
        private const UInt32 PROCESS_VM_READ = 0x010;
        public static string getfolder()
        {
            Int32 pid = Process.GetCurrentProcess().Id;
            int capacity = 2000;
            StringBuilder sb = new StringBuilder(capacity);
            IntPtr proc;
            if ((proc = NativeMethods.OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_VM_READ, false, pid)) == IntPtr.Zero)
                return "";
            NativeMethods.QueryFullProcessImageName(proc, 0, sb, ref capacity);
            string fullPath = sb.ToString(0, capacity);
            return Path.GetDirectoryName(fullPath) + @"\";
        }
    }
