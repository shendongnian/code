    DateTime result;
    string input = "9:00 PM";
    //use algorithm
    if (DateTime.TryParseExact(input, "H:mm tt", 
        CultureInfo.CurrentCulture, 
        DateTimeStyles.None, out result))
    {
        //end result
        int hour = result.Hour;
        string AMPM = result.ToString("tt");
    }
