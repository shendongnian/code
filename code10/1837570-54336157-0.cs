    var originalDate = "6/4/18 6:07 PM";
    DateTime parsedDate;
    var culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-AU");
    var styles = System.Globalization.DateTimeStyles.None;
    if (!DateTime.TryParse(originalDate, culture, styles, out parsedDate))
    {
           Console.WriteLine(parsedDate);
    }
            Console.WriteLine($"Parse successfull: {parsedDate}");
