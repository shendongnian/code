    public static void Main(string[] args)
    {
      try
      {
        TEST().Wait();
      }
      catch (Exception ex)
      {
        WriteLine($"There was an exception: {ex.ToString()}");
      }
    }
