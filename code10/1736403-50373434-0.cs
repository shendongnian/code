	bool isRainingCache;
	int lastChecked = Environment.TickCount - 1001;
	public bool IsRaining()
	{
	    int now = Environment.TickCount;
	    // If the last time we checked, it was raining, make sure it still is. OR
	    // If it hasn't been raining, only check again if we haven't checked in the past second.
	    if (isRainingCache || unchecked(now - lastChecked) > 1000)
	    {
		isRainingCache = ExternalService.IsRaining();
		lastChecked = now;
	    }
	    return isRainingCache;
	}
