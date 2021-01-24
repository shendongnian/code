     static void Main()
       {
          Timer timer = new Timer(new TimeSpan(0, 55, 0));
          timer.Elapsed += async ( sender, e ) => await HandleTimer();
          timer.Start();
          Console.Write("Press any key to exit... ");
          Console.ReadKey();
       }
    
       private static Task HandleTimer()
       {
         Console.WriteLine("\nHandler not implemented..." );
       }
    
