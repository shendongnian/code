    ConsoleKeyInfo k = new ConsoleKeyInfo();
    Console.WriteLine("Press any key in the next 5 seconds.");
    for (int cnt = 5; cnt > 0; cnt--)
      {
        if (Console.KeyAvailable == true)
          {
            k = Console.ReadKey();
            break;
          }
        else
         {
           Console.WriteLine(cnt.ToString());
           System.Threading.Thread.Sleep(1000);
         }
     }
    Console.WriteLine("The key pressed was " + k.Key);
