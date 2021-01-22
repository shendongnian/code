    public const long UnixEpochTicks = 621355968000000000;
    public const long TicksPerMillisecond = 10000;
    public const long TicksPerSecond = TicksPerMillisecond * 1000;
    
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime FromUnixTimestamp(this long unixTime)
    {
    	return new DateTime(UnixEpochTicks + unixTime * TicksPerSecond);
    }
