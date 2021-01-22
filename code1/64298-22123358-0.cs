    public enum DateTimeResolution
    {
    	Year, Month, Day, Hour, Minute, Second, Millisecond, Tick
    }
    public static DateTime Truncate(this DateTime self, DateTimeResolution resolution = DateTimeResolution.Second)
    {
    	switch (resolution)
    	{
    		case DateTimeResolution.Year:
    			return new DateTime(self.Year, 1, 1, 0, 0, 0, 0, self.Kind);
    		case DateTimeResolution.Month:
    			return new DateTime(self.Year, self.Month, 1, 0, 0, 0, self.Kind);
    		case DateTimeResolution.Day:
    			return new DateTime(self.Year, self.Month, self.Day, 0, 0, 0, self.Kind);
    		case DateTimeResolution.Hour:
    			return self.AddTicks(-(self.Ticks % TimeSpan.TicksPerHour));
    		case DateTimeResolution.Minute:
    			return self.AddTicks(-(self.Ticks % TimeSpan.TicksPerMinute));
    		case DateTimeResolution.Second:
    			return self.AddTicks(-(self.Ticks % TimeSpan.TicksPerSecond));
    		case DateTimeResolution.Millisecond:
    			return self.AddTicks(-(self.Ticks % TimeSpan.TicksPerMillisecond));
    		case DateTimeResolution.Tick:
    			return self.AddTicks(0);
    		default:
    			throw new ArgumentException("unrecognized resolution", "resolution");
    	}
    }
