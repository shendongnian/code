    ServiceController controller  = new ServiceController();
    controller.MachineName = "."; // or the remote machine name
    controller.ServiceName = "IISADMIN"; // or "w3svc"
    string status  = controller.Status.ToString();
    
    // Stop the service
    controller.Stop();
    
    // Start the service
    controller.Start();
