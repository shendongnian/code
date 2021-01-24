    class F1
    {
      public static F1 x = null;  
      public static F1 Start()
      {
        x = new F1();
        return x;
      }
      public static void Stop()
      {
        x = null;
      }
    }
    class F2
    {
      F1 y;
      void DoIt()
      {
        this.y = F1.Start();
        F1.Stop();
        Console.WriteLine(this.y == null); // false
      }
    }
