    static void Main(string[] args)
    {
      int counter = 0;
      Console.WriteLine(fun(ref counter)); // Prints 1
      Console.WriteLine(counter); // Prints 3
    }        
    
    static int fun(ref int counter)
    {
      try
        {
          counter = 1;
          return counter;
        }
        finally
        {
          counter = 3;
        }
    }
