    static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    static readonly double MaxUnixSeconds = (DateTime.MaxValue - UnixEpoch).TotalSeconds;
    
    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
       return unixTimeStamp > MaxUnixSeconds
          ? UnixEpoch.AddMilliseconds(unixTimeStamp)
          : UnixEpoch.AddSeconds(unixTimeStamp);
    }
