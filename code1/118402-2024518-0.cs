    DateTime resultDate;
    Console.WriteLine("CultureInfo.CurrentCulture.Calendar.TwoDigitYearMax : {0}", System.Globalization.CultureInfo.CurrentCulture.Calendar.TwoDigitYearMax);
    DateTime.TryParse("01/01/28", out resultDate);
    Console.WriteLine("Generated date with year=28 - {0}",resultDate);
    DateTime.TryParse("01/02/29",out resultDate);
    Console.WriteLine("Generated date with year=29 - {0}", resultDate);
    DateTime.TryParse("01/03/30", out resultDate);
    Console.WriteLine("Generated date with year=30 - {0}", resultDate);
