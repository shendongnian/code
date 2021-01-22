     var ServiceToRun = new SomeService(); 
     if (Environment.UserInteractive)
     {
        // This used to run the service as a console (development phase only)
    
        ServiceToRun.Start();
    
        Console.WriteLine("Press Enter to terminate ...");
        Console.ReadLine();
    
        ServiceToRun.DoStop();
     }
     else
     {
        ServiceBase.Run(ServiceToRun);
     }
