    List<TimeSpan> timeSpans = new List<TimeSpan>();
    for(int i = 0; i < array.Count; i++)
    {
        Stopwatch watch = Stopwatch.StartNew();
        //do stuff
        timeSpans.Add(new TimeSpan(watch.ElapsedTicks));
        long ticksLeft = timeSpans.Sum(ts => ts.Ticks) * (array.Count - i) / timeSpans.Count;
        Console.WriteLine("Left: " + new TimeSpan(ticksLeft));
        Console.WriteLine("Finished in: " + 
            DateTime.Now.AddTicks(ticksLeft));
    }
