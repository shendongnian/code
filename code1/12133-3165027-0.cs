    var backend = new Backend();
    if (Environment.UserInteractive)
    {
         backend.OnStart();
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new Fronend(backend));
         backend.OnStop();
    }
    else
    {
         var ServicesToRun = new ServiceBase[] {backend};
         ServiceBase.Run(ServicesToRun);
    }
