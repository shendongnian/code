    var parsedDate = DateTime.MinValue;
    var inputDateString = "12/31/2017 12:00:00 AM"; // false, but I want to parse
    // option 1: use only the date part
    if (DateTime.TryParseExact((inputDateString ?? "").Split(' ')[0] , "M/d/yyyy", 
            CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
        Console.WriteLine(parsedDate);
    // option 2: use the full input, but ignore the time
    if (DateTime.TryParseExact(inputDateString, "M/d/yyyy hh:mm:ss tt", 
            CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
        Console.WriteLine(parsedDate.Date);
