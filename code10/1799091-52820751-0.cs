    if (Environment.UserInteractive)
    {
          //**** this is for debugging in console mode
    }
    else
    {
         //*** this is for running as a Windows service
         var ServicesToRun = new ServiceBase[]
         {
              new ServiceHome()
         };
         ServiceBase.Run(ServicesToRun);
    }
