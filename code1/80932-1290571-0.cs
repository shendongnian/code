    [ConfigurationProperty("Time", IsRequired=true)]
    public DateTime Time
    {
        get
        {
            return DateTime.ParseExact(
                this["Time"].ToString(),
                "yyyy-MM-dd HH:mm:ss",
                CultureInfo.InvariantCulture);
        }
        set
        {
            this["Time"] = value.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
