    public readonly DateTime UnixEpoch = new DateTime(1970, 1, 1);
    // equivalent to PHP mktime :
    public int GetUnixTimestamp(DateTime dt)
    {
        TimeSpan span = dt - UnixEpoch;
        return (int)span.TotalSeconds;
    }
