    public TimeSpan SystemTime { get; set; }
    public string SystemTimeAsString
    {
        get
        {
            // Note: ignoring fractional seconds.
            return $"{(int)SystemTime.TotalHours}:SystemTime.Minutes.ToString("00")}:SystemTime.Seconds.ToString("00")}";
        }
    }
