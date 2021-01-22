    int i = 1;
    System.Timers.Timer t = new System.Timers.Timer(1);
    t.Elapsed += new ElapsedEventHandler(
      (sender, e) => { if (i > 100) t.Enabled = false; else Console.WriteLine(i++); });
    t.Enabled = true;
    Thread.Sleep(110);
