    class Test
    {
      static void Main() //This will be an MTA thread by default
      {
        var o = new COMObjectClass();
        // Did a new thread pop into existence when that line was executed?
        // If so, .NET created an STA thread for it to live in.
      }
    }
