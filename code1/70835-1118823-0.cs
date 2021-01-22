    var delegates = new List<Delegate>();
    var actions = new List<Action<object>>();
    const int dataCount = 100;
    const int loopCount = 10000;
    for (int i = 0; i < dataCount; i++)
    {
        Action<int> a = d => { };
        delegates.Add(a);
        actions.Add(o => a((int)o));
    }
    var sw = Stopwatch.StartNew();
    for (int i = 0; i < loopCount; i++)
    {
        foreach (var action in actions)
            action(i);
    }
    Console.Out.WriteLine("{0:#,##0} Action<object> calls in {1:#,##0.###} ms",
        loopCount * dataCount, sw.Elapsed.TotalMilliseconds);
    sw = Stopwatch.StartNew();
    for (int i = 0; i < loopCount; i++)
    {
        foreach (var del in delegates)
            del.DynamicInvoke(i);
    }
    Console.Out.WriteLine("{0:#,##0} DynamicInvoke calls in {1:#,##0.###} ms",
        loopCount * dataCount, sw.Elapsed.TotalMilliseconds);
