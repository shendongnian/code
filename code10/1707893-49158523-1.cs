    private StopWatch stopwatch;
    public TimeSpan timeElapsed { get; private set; }
    private void Start()
    {
        stopwatch = new StopWatch();
        stopwatch.Start();
    }
    private void Update()
    {
        timeElapsed = stopwatch.ElapsedMilliseconds;
    }
