    public static void Main()
    {
      string text = "Hello World";
      var thread = new Thread(
        () =>
        {
          Console.WriteLine(text); // variable read by worker thread
        });
      thread.Start();
      Console.WriteLine(text); // variable read by main thread
    }
