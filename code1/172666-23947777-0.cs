    public static partial class ConsoleEx
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetConsoleHistoryInfo(CONSOLE_HISTORY_INFO ConsoleHistoryInfo);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetConsoleHistoryInfo(CONSOLE_HISTORY_INFO ConsoleHistoryInfo);
        [StructLayout(LayoutKind.Sequential)]
        private class CONSOLE_HISTORY_INFO
        {
            public uint cbSize;
            public uint BufferSize;
            public uint BufferCount;
            public uint TrimDuplicates;
        }
        public static void ClearConsoleHistory()
        {
            var chi = new CONSOLE_HISTORY_INFO();
            chi.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(CONSOLE_HISTORY_INFO));
            if (!GetConsoleHistoryInfo(chi))
            {
                return;
            }
            var originalBufferSize = chi.BufferSize;
            chi.BufferSize = 0;
            if (!SetConsoleHistoryInfo(chi))
            {
                return;
            }
            chi.BufferSize = originalBufferSize;
            if (!SetConsoleHistoryInfo(chi))
            {
                return;
            }
        }
    }
 
