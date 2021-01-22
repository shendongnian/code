    public static DateTime Now
    {
        get
        {
            return UtcNow.ToLocalTime();
        }
    }
