     DateTime.ParseExact(
      "2009-12-28T24:11:48Z",
      new []{ "yyyy-MM-ddTHH:mm:ssK", "yyyy-MM-ddT24:mm:ssK" }, 
      System.Globalization.CultureInfo.InvariantCulture,
      System.Globalization.DateTimeStyles.None
    )
