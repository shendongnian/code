    public static void DoWork(Action processAction)
    {
      // do work
      if (processAction != null)
        processAction();
    }
    
    public static void Main()
    {
      // using anonymous delegate
      DoWork(delegate() { Console.WriteLine("Completed"); });
    
      // using Lambda
      DoWork(() => Console.WriteLine("Completed"));
    }
