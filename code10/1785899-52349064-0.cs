    public AaTrend(string[] args, ILogger logger = null)
    {
        _logger = logger;
        _logger?.WriteLine("Initialising new aaTrend object...");
        if (args == null || args.Length < 1) args = new[] { "" };
        _tempFilePath = GenerateTempFileName();
        CreateTempCopy(); //Needed to bypass lazy single instance checks
        HideTempFile(); //Stops users worrying
        ProcessStartInfo info = new ProcessStartInfo(_tempFilePath, args.Aggregate((s, c) => $"{s} {c}"));
        _process = new Process { StartInfo = info };
    }
