    System.Timers.Timer t;
    void Main()
    {
      t = new System.Timers.Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
      t.AutoReset = true;
      t.Elapsed += new System.Timers.ElapsedEventHandler(startAutoSpec);
      t.Start();
    }
    void SomeOtherFunction()
    {
      t.Stop();
    }
