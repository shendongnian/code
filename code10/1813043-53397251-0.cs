    public static double GetHours(string timeString)
    {
        var splitTime = timeString.Split(':');
        if (splitTime.Length != 3)
            throw new ArgumentException("Time string not in format HH:MM:SS");
        var hours = Convert.ToDouble(splitTime[0]);
        var mins = Convert.ToDouble(splitTime[1]);
        var seconds = Convert.ToDouble(splitTime[2]);
        var time = new TimeSpanBuilder()
            .WithHours(hours)
            .WithMinutes(mins)
            .WithSeconds(seconds)
            .Build();
        return time.TotalHours;
    }
