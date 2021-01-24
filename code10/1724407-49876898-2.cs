    public TimeSpan CalculatedTime
    {
        get
        {
           return Time.Subtract(TimeSpan.FromHours(1));
        }
    }
