    using System.Globalization;
    
    DateTime d;
    DateTime.TryParseExact(
        "2010-08-20T15:00:00",
        "s",
        CultureInfo.InvariantCulture,
        DateTimeStyles.AssumeUniversal, out d);
