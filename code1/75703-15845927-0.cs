    #if DEBUG
        [STAThread]
    #endif
        static void Main()
        {
    try
            {
    #if DEBUG
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DebugForm());
    #else
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			{ 
				new YourWindowsService() 
			};
                ServiceBase.Run(ServicesToRun);
    #endif
            }
            catch (Exception e)
            {
                logger.Error(DateTime.Now.ToString() + " - " + e.Source + " - " + e.ToString() + "\r\n------------------------------------\r\n");
            }
    }
