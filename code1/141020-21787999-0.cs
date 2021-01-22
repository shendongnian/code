        [MTAThread()]
        private static void Main()
        {
            if (!Environment.UserInteractive)
            {
                ServiceBase[] aServicesToRun;
                // More than one NT Service may run within the same process. To add
                // another service to this process, change the following line to
                // create a second service object. For example,
                //
                //   ServicesToRun = New System.ServiceProcess.ServiceBase () {New ServiceMain, New MySecondUserService}
                //
                aServicesToRun = new ServiceBase[] {new ServiceMain()};
                Run(aServicesToRun);
            }
            else
            {
                var oService = new ServiceMain();
                oService.OnStart(null);
            }
       }
