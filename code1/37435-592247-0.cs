    public void WriteText() {
      Console.WriteLine("Hello");
    }
    ...
    Action x = WriteText;
    x(); // will invoke the WriteText function
