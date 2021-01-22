    public static string FunnyEncode(string day, string time) {
        DateTime dt = DateTime.Parse(DateTime.Today.ToString("MM/dd/yyyy")+" "+time+":00");
        while (dt.DayOfWeek != "Monday")
            dt = dt.AddDays(1);
        return dt.ToString("MM:dd:yyyy HH:mm");
    }
