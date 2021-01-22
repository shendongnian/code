    public static StopWatch TimedFor(this DependencyObject source, Int32 loops, Action action)
    {
    var sw = new Stopwatch();
    sw.Start();
    for (int i = 0; i < loops; ++i)
    {
        action.Invoke();
    }
    sw.Stop();
    
    return sw;
    }
