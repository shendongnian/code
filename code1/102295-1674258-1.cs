    private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 
                                                          DateTimeKind.Utc);
    ...
    public static DateTime UnixTimeToDateTime(string text)
    {
        double seconds = double.Parse(text, CultureInfo.InvariantCulture);
        return Epoch.AddSeconds(seconds);
    }
