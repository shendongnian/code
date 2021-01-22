    using System.ServiceProcess;
    ServiceController controller  = new ServiceController();
    
    controller.MachineName = ".";
    controller.ServiceName = "mysql";
    // Start the service
    controller.Start();
    // Stop the service
    controller.Stop();
