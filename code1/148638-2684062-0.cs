    public static int UnixTimestamp()
    {
        var utcEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        var utcNow = DateTime.UtcNow;
        var span = utcNow - utcEpoch;
        return (int)span.TotalSeconds;
    }
