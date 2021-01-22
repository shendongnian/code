    public static void DoWork(Action<string> processAction)
    {
      // do work
      if (processAction != null)
        processAction("this is the string");
    }
    
    public static void Main()
    {
      // using anonymous delegate
      DoWork(delegate(string str) { Console.WriteLine(str); });
    
      // using Lambda
      DoWork((str) => Console.WriteLine(str));
    }
