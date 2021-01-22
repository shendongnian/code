    public static void Reset(this Timer timer)
    {
      timer.Stop();
      timer.Start();
    }
