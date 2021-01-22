    public static class ConsoleEx
    {
      public static string ReadLine(TimeSpan timeout)
      {
        var cts = new CancellationTokenSource();
        return ReadLine(timeout, cts.Token);
      }
    
      public static string ReadLine(TimeSpan timeout, CancellationToken cancellation)
      {
        string line = "";
        DateTime latest = DateTime.UtcNow.Add(timeout);
        do
        {
            cancellation.ThrowIfCancellationRequested();
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Enter)
                {
                    return line;
                }
                else
                {
                    line += cki.KeyChar;
                }
            }
            Thread.Sleep(1);
        }
        while (DateTime.UtcNow < latest);
        return null;
      }
    }
