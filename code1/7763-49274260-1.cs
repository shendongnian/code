    static class Program
    {
        
        static void Main()
        {
          
            #if DEBUG
            // TODO: Add code to start application here
            //    //If the mode is in debugging
            //    //create a new service instance
            Service1 myService = new Service1();
            //    //call the start method - this will start the Timer.
             myService.Start();
            //    //Set the Thread to sleep
             Thread.Sleep(300000);
            //    //Call the Stop method-this will stop the Timer.
            myService.Stop();
             #else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Service1() 
            };
            ServiceBase.Run(ServicesToRun);
             #endif
        }
    }
