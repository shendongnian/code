    DateTime.TryParseExact
    (
        theDate.PadLeft(8,'0'), 
        "ddMMyyyy", 
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None, 
        out date
    );
