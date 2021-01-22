    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    ...
        public static void SetUnmanagedDllDirectory() {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            path = Path.Combine(path, IntPtr.Size == 8 ? "x64 " : "x86");
            if (!SetDllDirectory(path)) throw new System.ComponentModel.Win32Exception();
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string path);
