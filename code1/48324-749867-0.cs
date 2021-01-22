    private static ManualResetEvent m_daemonUp = new ManualResetEvent(false);
    [STAThread]
    static void Main(string[] args)
    {
        bool isConsole = false;
        if (args != null && args.Length == 1 && args[0].StartsWith("-c")) {
            isConsole = true;
            Console.WriteLine("Daemon starting");
            MyDaemon daemon = new MyDaemon();
            Thread daemonThread = new Thread(new ThreadStart(daemon.Start));
            daemonThread.Start();
            m_daemonUp.WaitOne();
        }
        else {
            System.ServiceProcess.ServiceBase[] ServicesToRun;
            ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Service() };
            System.ServiceProcess.ServiceBase.Run(ServicesToRun);
        }
    }
