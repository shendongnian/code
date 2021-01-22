    static void Main()
    {
        System.ServiceProcess.ServiceBase[] ServicesToRun;
        // Change the following line to match.
        ServicesToRun = new System.ServiceProcess.ServiceBase[] { new WindowsServiceToHostASMXWebService() };
        System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    }
