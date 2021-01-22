    static void Main()
    {
    #if (!DEBUG)
        System.ServiceProcess.ServiceBase[] ServicesToRun;
        ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Service1() };
        System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    #else
        // Debug code: this allows the process to run as a non-service.
    
        // It will kick off the service start point, but never kill it.
    
        // Shut down the debugger to exit
    
        Service1 service = new Service1();
        service.<Your Service's Primary Method Here>();
        // Put a breakpoint on the following line to always catch
        // your service when it has finished its work
        System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
    #endif 
    }
