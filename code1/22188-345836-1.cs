        static void Main(string[] args)
        {
            // Getting all instances of notepad
            // (this is only done once here so start up some notepad instances first)
            // you may want use GetProcessByPid or GetProcesses and filter them as required
            Process[] processesToWatch = Process.GetProcessesByName("notepad");
            foreach (var process in processesToWatch)
            {
                process.EnableRaisingEvents = true;
                process.Exited +=
                    (s, e) => Console.WriteLine("An instance of notepad exited");
            }
            Thread watchThread = new Thread(() =>
                {
                    while (true)
                    {
                        Process[] processes = Process.GetProcesses();
                        foreach (var process in processes)
                        {
                            Console.WriteLine("{0}:{1}", process.Id, process.ProcessName);
                        }
                        // Don't dedicate a thread to this like I'm doing here
                        // setup a timer or something similiar
                        Thread.Sleep(2000);
                    }
                });
            watchThread.IsBackground = true;
            watchThread.Start();
            Console.WriteLine("Polling processes and waiting for notepad process exit events");
            Console.ReadLine();
        }
