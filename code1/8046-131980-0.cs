    string input = "08:00";
    DateTime time;
    if (!DateTime.TryParse(input, out time))
    {
        // invalid input
        return;
    }
    TimeSpan timeSpan = new TimeSpan(time.Hour, time.Minute, time.Second);
   
