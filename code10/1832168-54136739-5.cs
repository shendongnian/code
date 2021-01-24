    public static void Main(string[] args)
    {
      try
      {
        TEST().GetAwaiter().GetResult();
      }
      catch (Exception ex)
      {
        WriteLine($"There was an exception: {ex.ToString()}");
      }
    }
