      Stopwatch sw = new Stopwatch();
      sw.Start();
      System.Threading.Thread.Sleep(100);
      sw.Stop();
      Debug.WriteLine(sw.ElapsedTicks);
      sw.Start();
      System.Threading.Thread.Sleep(100);
      sw.Stop();
      Debug.WriteLine(sw.ElapsedTicks);
