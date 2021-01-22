        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int pid);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && (args[0].Equals("/?") || args[0].Equals("/help", StringComparison.OrdinalIgnoreCase)))
            {
                // get console output
                if (!AttachConsole(-1))
                    AllocConsole();
                ShowHelp(); // show help output with Console.WriteLine
                FreeConsole(); // detach console
                // get command prompt back
                System.Windows.Forms.SendKeys.SendWait("{ENTER}"); 
                return;
            }
            // normal winforms code
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
