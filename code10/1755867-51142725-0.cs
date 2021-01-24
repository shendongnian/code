    public static long ToUTC(this DateTime _input)
    {
        var utcTime = _input.ToUniversalTime();
        var totalSeconds = utcTime.Subtract(UnixEpoch).TotalSeconds;
        return Convert.ToInt64(totalSeconds);
    }
