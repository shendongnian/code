        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();
        [DllImport("kernel32", SetLastError = true)]
        private static extern bool AttachConsole(int dwProcessId);
        private const uint STD_INPUT_HANDLE = 0xfffffff6;
        private const uint STD_OUTPUT_HANDLE = 0xfffffff5;
        private const uint STD_ERROR_HANDLE = 0xfffffff4;
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(uint nStdHandle);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern int SetStdHandle(uint nStdHandle, IntPtr handle);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int GetConsoleProcessList(int[] ProcessList, int ProcessCount);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// Attach to existing console or create new. Must be called before using System.Console.
        /// </summary>
        /// <returns>Return true if console exists or is created.</returns>
        public static bool InitConsole(bool createConsole = false, bool suspendHost = true) {
            // first try to attach to an existing console
            if (AttachConsole(-1)) {
                if (suspendHost) {
                    // to suspend the host first try to find the parent
                    var processes = GetConsoleProcessList();
                    Process host = null;
                    string blockingCommand = null;
                    foreach (var proc in processes) {
                        var netproc = Process.GetProcessById(proc);
                        var processName = netproc.ProcessName;
                        Console.WriteLine(processName);
                        if (processName.Equals("cmd", StringComparison.OrdinalIgnoreCase)) {
                            host = netproc;
                            blockingCommand = $"powershell \"& wait-process -id {Process.GetCurrentProcess().Id}\"";
                        } else if (processName.Equals("powershell", StringComparison.OrdinalIgnoreCase)) {
                            host = netproc;
                            blockingCommand = $"wait-process -id {Process.GetCurrentProcess().Id}";
                        }
                    }
                    if (host != null) {
                        // if a parent is found send keystrokes to simulate a command
                        var cmdWindow = host.MainWindowHandle;
                        if (cmdWindow == IntPtr.Zero) Console.WriteLine("Main Window null");
                        foreach (char key in blockingCommand) {
                            SendChar(cmdWindow, key);
                            System.Threading.Thread.Sleep(1); // required for powershell
                        }
                        SendKeyDown(cmdWindow, Keys.Enter);
                        // i haven't worked out how to get powershell to accept a command, it might be that this is a security feature of powershell
                        if (host.ProcessName == "powershell") Console.WriteLine("\r\n *** PRESS ENTER ***");
                    }
                }
                return true;
            } else if (createConsole) {
                return AllocConsole();
            } else {
                return false;
            }
        }
        private static void SendChar(IntPtr cmdWindow, char k) {
            const uint WM_CHAR = 0x0102;
            
            IntPtr result = PostMessage(cmdWindow, WM_CHAR, ((IntPtr)k), IntPtr.Zero);
        }
        private static void SendKeyDown(IntPtr cmdWindow, Keys k) {
            const uint WM_KEYDOWN = 0x100;
            const uint WM_KEYUP = 0x101;
            IntPtr result = SendMessage(cmdWindow, WM_KEYDOWN, ((IntPtr)k), IntPtr.Zero);
            System.Threading.Thread.Sleep(1);
            IntPtr result2 = SendMessage(cmdWindow, WM_KEYUP, ((IntPtr)k), IntPtr.Zero);
        }
        public static int[] GetConsoleProcessList() {
            int processCount = 16;
            int[] processList = new int[processCount];
            
            // supposedly calling it with null/zero should return the count but it didn't work for me at the time
            // limiting it to a fixed number if fine for now
            processCount = GetConsoleProcessList(processList, processCount);
            if (processCount <= 0 || processCount >= processList.Length) return null; // some sanity checks
            return processList.Take(processCount).ToArray();
        }
