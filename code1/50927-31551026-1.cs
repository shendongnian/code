       public App()
       {
          AppDomain currentDomain = AppDomain.CurrentDomain;
          currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);    
       }
    
       static void MyHandler(object sender, UnhandledExceptionEventArgs args) 
       {
          Exception e = (Exception) args.ExceptionObject;
          Console.WriteLine("MyHandler caught : " + e.Message);
          Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
       }
