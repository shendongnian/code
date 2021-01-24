    Console.WriteLine("start");
    Task.Run(async () =>
     {
         await Task.Delay(200);
          Console.WriteLine("Finished");
     });
               
     for(int i = 0; i < 500; i++)
        {
           Console.WriteLine(i);
        }
    Console.WriteLine("end");
    Console.ReadKey();
