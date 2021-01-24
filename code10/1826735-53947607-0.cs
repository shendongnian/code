    List<DateTime> validDates = new List<DateTime>();
    List<DateTime> invalidDates = new List<DateTime>();
    List<string> dateTimes = new List<string>() {
        "20181227",
        "2018-12-27",
        "27/12/2018",
        "12/27/2018"
    }; //INSTEAD OF DECLARING THE DATES, THERE SHOULD BE THE CONVERSION FROM JSON TO STRINGS LIST    
    foreach(string dateTime in dateTimes)
    {
        bool isValid = DateTime.TryParseExact(dateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);
        if (isValid)
        {
            validDates.Add(result);
        }
        else
        {
            invalidDates.Add(result);
        }
    }
