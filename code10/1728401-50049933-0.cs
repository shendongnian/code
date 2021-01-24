    public LogCurve(string name, int serverCount)
    {
        Name = name;
        LogPoints = new List<LogCurveDataPoint >();
        ServerCount = serverCount;
		PropertyChanged = null;
    }
