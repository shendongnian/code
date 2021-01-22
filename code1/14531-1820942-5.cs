    public void Execute(Action action, int n)
    {
        var time = action.Iterations(n).Benchmark()
        log.DebugFormat(“Did action {0} times in {1} ms.”, n, time);
    }
