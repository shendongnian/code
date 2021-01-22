    public static Stopwatch MeasureTime<T>(int iterations, Action<T> action, T param)
    {
        var sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < iterations; i++)
        {
            action.Invoke(param);
        }
        sw.Stop();
        return sw;
    }
    public static Stopwatch MeasureTime<T, K>(int iterations, Action<T, K> action, T param1, K param2)
    {
        var sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < iterations; i++)
        {
            action.Invoke(param1, param2);
        }
        sw.Stop();
        return sw;
    }
