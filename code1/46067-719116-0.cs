    class Program
    {
      static void Main(string[] args)
      {
        TestNullBool(true);
        TestNullBool(false);
        TestNullBool(null);
        Console.ReadKey();
      }
    
      private static void TestNullBool(bool? result)
      {
        if (result == null)
        {
          Console.WriteLine("Result is null");
        }
        if (result == false)
        {
          Console.WriteLine("Result is false");
        }
        if (result == true)
        {
          Console.WriteLine("Result is true");
        }
      }
    }
    /* Output:
    Result is true
    Result is false
    Result is null
    */
