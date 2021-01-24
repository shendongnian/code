    // Check whether the service is started.
    ServiceController sc  = new ServiceController();
    sc.ServiceName = "MyAwesomeService";
    Console.WriteLine("The MyAwesomeService status is currently set to {0}", 
                       sc.Status.ToString());
    
    if (sc.Status == ServiceControllerStatus.Stopped)
    {
       // Start the service if the current status is stopped.
       Console.WriteLine("Starting MyAwesomeService...");
       try 
       {
          // Start the service, and wait until its status is "Running".
          sc.Start();
          sc.WaitForStatus(ServiceControllerStatus.Running);
    
          // Display the current service status.
          Console.WriteLine("The MyAwesomeService is now set to {0}.", 
                             sc.Status.ToString());
       }
       catch (InvalidOperationException)
       {
          Console.WriteLine("Could not start the MyAwesomeService.");
       }
    }
