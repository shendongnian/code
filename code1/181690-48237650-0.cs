    private static bool IsInputRedirected()
    {
      try
      {
        if (Console.KeyAvailable)
        {
          return (false);
        }
      }
      catch (InvalidOperationException)
      {
        return (true);
      }
      return (false);
    }
