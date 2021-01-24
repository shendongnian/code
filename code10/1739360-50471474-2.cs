    public static DateTime RoundToTheTwoHundredthMillisecond(DateTime dt)
    {
        var ms = Math.Round(dt.Millisecond / 200.0, MidpointRounding.ToEven) * 200;
        return dt.AddMilliseconds(ms- dt.Millisecond);
    }
