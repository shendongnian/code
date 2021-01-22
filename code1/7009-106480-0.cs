    public static void Invoke(Delegate d)
    {
      d.DynamicInvoke();
    }
    
    static void Main(string[] args)
    {
      // fails
      Invoke(() => Console.WriteLine("Test"));
    
      // works
      Invoke(new Action(() => Console.WriteLine("Test")));
    
      Console.ReadKey();
    }
