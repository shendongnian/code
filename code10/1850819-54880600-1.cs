    try {
      try {
        throw new Exception();
      }
      catch (ArgumentOutOfRangeException ex)
      {
        Console.WriteLine("No!");
      }
      finally
      {
        Console.WriteLine("A");
      }
    }
    catch (Exception ex2)
    {
      Console.WriteLine("B");
    }
    finally
    {
      Console.WriteLine("C");
    }
