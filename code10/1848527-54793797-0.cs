    class F1
    {
      static int x = 0;  
      public static int Start()
      {
        x = 1;
        return x;
      }
      public static void Stop()
      {
        x = 0;
      }
    }
    class F2
    {
      int y;
      void DoIt()
      {
        this.y = F1.Start();
        F1.Stop();
        Console.WriteLine(this.y);
      }
    }
