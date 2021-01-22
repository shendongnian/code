    //...
    string detailLastDate = "090722";
    DateTime lastDate;
    
    if (!DateTime.TryParseExact(detailLastDate, "yymmdd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out lastDate))
    {
        // input doesn't match the format
        lastDate = new DateTime(1999, 12, 31); // default value 991231
    }
    //...
    return (lastDate - DateTime.Today).Days;
