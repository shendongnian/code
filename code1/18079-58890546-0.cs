        static void RunFFMpeg(string arguments)
        {
            var startup = new STARTUPINFO();
            startup.cb = Marshal.SizeOf<STARTUPINFO>();
            if (!CreateProcess(null, "ffmpeg.exe " + arguments, IntPtr.Zero, IntPtr.Zero, false, 0, IntPtr.Zero, null, ref startup, out var info))
                throw new Win32Exception(Marshal.GetLastWin32Error());
            CloseHandle(info.hProcess);
            CloseHandle(info.hThread);
            var process = Process.GetProcessById(info.dwProcessId);
            Console.CancelKeyPress += (s, e) =>
            {
                process.WaitForExit();
                Console.WriteLine("Abort.");
                // end of program is here
            };
            process.WaitForExit();
            Console.WriteLine("Exit.");
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct STARTUPINFO
        {
            public int cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public int dwX;
            public int dwY;
            public int dwXSize;
            public int dwYSize;
            public int dwXCountChars;
            public int dwYCountChars;
            public int dwFillAttribute;
            public int dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
        [DllImport("kernel32")]
        private static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool CreateProcess(
           string lpApplicationName,
           string lpCommandLine,
           IntPtr lpProcessAttributes,
           IntPtr lpThreadAttributes,
           bool bInheritHandles,
           int dwCreationFlags,
           IntPtr lpEnvironment,
           string lpCurrentDirectory,
           ref STARTUPINFO lpStartupInfo,
           out PROCESS_INFORMATION lpProcessInformation);
