    static void Main(string[] args)
    {
       if ( args == "blah") 
       {
          MyService();
       } 
       else 
       {
          System.ServiceProcess.ServiceBase[] ServicesToRun;
          ServicesToRun = new System.ServiceProcess.ServiceBase[] { new MyService() };
          System.ServiceProcess.ServiceBase.Run(ServicesToRun);
       }
