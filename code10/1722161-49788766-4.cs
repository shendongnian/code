     static void Main()
       {
          Timer timer = new Timer(intvalue); //intvalue equal to 55 min
          timer.Elapsed += async ( sender, e ) => await HandleTimer();
          timer.Start();
          Console.Write("Press any key to exit... ");
          Console.ReadKey();
       }
    
       private static Task HandleTimer()
       {
         Console.WriteLine("\nHandler not implemented..." );
       }
    
