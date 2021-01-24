     public static void CountKeyPresses()
     {
         Console.WriteLine("OK, start pressing the space bar");
         var numPresses = 0;
         var stopWatch = new Stopwatch();
         stopWatch.Start();
         while (stopWatch.ElapsedMilliseconds < 4000)
         {
             if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Spacebar)
             {
                 ++numPresses;
             }
             System.Threading.Thread.Sleep(10);
         }
         Console.WriteLine($"\r\nYou pressed the spacebar {numPresses} times");
     }
