    class F1
    {
      static int x = 0;  
      public static ref int Start()
      {
        x = 1;
        return ref x;
      }
      public static void Stop()
      {
        x = 0;
      }
    }
    class F2
    {
      void DoIt()
      {
        ref int y = ref F1.Start();
        F1.Stop();
        Console.WriteLine(y); // 0
      }
    }
