        [DllImport("Kernel32.Dll")]
        public static extern uint VirtualQueryEx(IntPtr ProcessHandle, uint Address, ref MEMORY_BASIC_INFORMATION MemInfo, int MemInfoLength);
        [DllImport("Kernel32.Dll")]
        public static extern bool ReadProcessMemory(IntPtr ProcessHandle, uint Address, byte[] Buffer, uint Size, ref uint BytesRead);
        [DllImport("Kernel32.Dll")]
        public static extern bool WriteProcessMemory(IntPtr ProcessHandle, uint Address, byte[] Buffer, uint Size, ref uint BytesRead);
