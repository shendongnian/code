    /// Assumes time is formatted as 08:15 and not 08:15:00
    public static string FunnyEncode(string day, string time) {
        DateTime dt = DateTime.Parse(
            DateTime.Today.ToString("MM/dd/yyyy") + " " + time + ":00");
        while (dt.DayOfWeek != day) // i.e. "Monday"
            dt = dt.AddDays(1);
        return dt.ToString("MM:dd:yyyy HH:mm");
    }
