    string dateTime = "2018-6-18 20:50:35";
    DateTime parsedDateTime;
    if(DateTime.TryParse(dateTime, out parsedDateTime))
    {
        return parsedDateTime.ToString("yyyy-M-d hh:mm tt");
    }
