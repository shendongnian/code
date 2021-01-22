    // 10000000 runs
    DateTime d = DateTime.Now;
    // 484,375ms
    d = new DateTime((d.Ticks / TimeSpan.TicksPerSecond) * TimeSpan.TicksPerSecond);
    // 1296,875ms
    d = d.AddMilliseconds(-d.Millisecond);
