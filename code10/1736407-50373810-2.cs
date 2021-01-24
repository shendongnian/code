    bool isRainingCache;
    Stopwatch stopwatch = Stopwatch.StartNew();
    public bool IsRaining()
    {
        DateTime now = DateTime.Now;
        // If the last time we checked, it was raining, make sure it still is. OR
        // If it hasn't been raining, only check again if we haven't checked in the past second.
        if (isRainingCache || stopwatch.ElapsedMilliseconds > 1000)
        {
            isRainingCache = ExternalService.IsRaining();
            stopwatch.Restart();
        }
        return isRainingCache;
    }
