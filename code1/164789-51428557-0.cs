        public static void WriteToConsole(string message)
        {
            AttachConsole(-1);
            System.Console.WriteLine(message);
            SendKeys.SendWait("{ENTER}");
            FreeConsole();
        }
        [DllImport("Kernel32.dll")]
        private static extern bool AttachConsole(int processId);
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();
