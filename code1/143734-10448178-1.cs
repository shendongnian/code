        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();
        public void RunConsole(string[] args)
        {
            OnStart(args);
            AllocConsole();
            Console.WriteLine("Service running ... press <ENTER> to stop");
            Console.ReadLine();
            FreeConsole();
            OnStop();
        }
