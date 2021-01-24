    Console.WriteLine("start");
    
    Task.Delay(2000).Wait(); // It'll wait for 2 seconds before continue.
               
    for(int i = 0; i < 500; i++)
      {
         Console.WriteLine(i);
      }
     Console.WriteLine("end");
     Console.ReadKey();
