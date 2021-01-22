    // TimeSpan ticks are 100 ns.
    const Int32 TimeSpanTicksPerSecond = 10000000;
    var performanceCounterTicks =
      timeSpan.Ticks*Stopwatch.Frequency/TimeSpanTicksPerSecond;
    averageTimerCounter.IncrementBy(unchecked((int) performanceCounterTicks));
    averageTimerCounterBase.Increment();
