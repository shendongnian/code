    static void Main()
    {
      StringBuilder msg = new StringBuilder(10);
      var endTime = DateTime.Now.AddSeconds(10);
      while (endTime > DateTime.Now)
      {
        if (Console.KeyAvailable)
        {
          ConsoleKeyInfo key = Console.ReadKey();
          msg.Append(key.KeyChar);
        }
        Thread.Sleep(1);
        Console.Write("\r Enter the message within {0} seconds; message = {1}", (endTime - DateTime.Now).Seconds, msg);
      }
    }
