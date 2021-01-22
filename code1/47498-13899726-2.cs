    public static void Benchmark(Action method, int iterations = 10000)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < iterations; i++)
            method();
        sw.Stop();
        MsgBox.ShowDialog(sw.Elapsed.TotalMilliseconds.ToString());
    }
