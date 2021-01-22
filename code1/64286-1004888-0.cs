    // 10000000 runs
    DateTime d = DateTime.Now;
    // 734,375ms
    d = DateTime.FromBinary((d.Ticks / TimeSpan.TicksPerSecond) * TimeSpan.TicksPerSecond)
    // 1296,875ms
    d = d.AddMilliseconds(-d.Millisecond);
