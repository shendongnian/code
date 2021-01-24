      string[] tests = new string[] {
        "01/05/2018",
        "01/may/2018",
      };
      string[] formats = new string[] {
        "d/M/yyyy",    // try this format first
        "d/MMMM/yyyy", // on fail try this one etc.
      };
      string[] results = tests
        .Select(item => DateTime.ParseExact(item, 
                                            formats,
                                            CultureInfo.InvariantCulture, 
                                            DateTimeStyles.AssumeLocal))
        .Select(date => date.ToString("dd'/'MM'/'yyyy")) // '/' - to preserve / 
        .ToArray();
      Console.Write(Environment.NewLine, results);
