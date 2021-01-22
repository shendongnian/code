    System.Globalization.CultureInfo cultureInfo =
                new System.Globalization.CultureInfo("en-CA");
            // Defining various date and time formats.
            dateTimeInfo.LongDatePattern = "yyyyMMdd";
            dateTimeInfo.ShortDatePattern = "yyyyMMdd";
            dateTimeInfo.FullDateTimePattern = "yyyyMMdd";
            // Setting application wide date time format.
            cultureInfo.DateTimeFormat = dateTimeInfo;
        // Assigning our custom Culture to the application.
        //Application.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;
    
    DateTime.Parse(excelDate);
