    bool success = DateTime.TryParse("30-05-2010", out dt);
    Console.Write(success); // false
    // use French rules...
    success = DateTime.TryParse("30-05-2010", new CultureInfo("fr-FR"),
                  System.Globalization.DateTimeStyles.AssumeLocal, out dt);
    Console.Write(success); // true
