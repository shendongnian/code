    static bool exiting = false;
    static void Main(string[] args)
    {
       try
       {
          System.Threading.Thread demo = new System.Threading.Thread(DemoThread);
          AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
          demo.Start();
          Console.ReadLine();
          exiting = true;
       }
       catch (Exception ex)
       {
          Console.WriteLine("Caught an exception");
       }
    }
    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
       Console.WriteLine("Notified of a thread exception... application is terminating.");
    }
    static void DemoThread()
    {
       for(int i = 5; i >= 0; i--)
       {
          Console.Write("24/{0} =", i);
          Console.Out.Flush();
          Console.WriteLine("{0}", 24 / i);
          System.Threading.Thread.Sleep(1000);
          if (exiting) return;
       }
    }
