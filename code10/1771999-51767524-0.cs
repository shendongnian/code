    string s = "\t 1998-07-31 12:00:00Z "; // has leading and trailing whitespace
    DateTime dt;
    // Prints True: TryParse does not care.
    Console.WriteLine(DateTime.TryParse(s, null, DateTimeStyles.None, out dt));
    // Prints False: TryParseExact does not like whitespace.
    Console.WriteLine(DateTime.TryParseExact(s, "u", null, DateTimeStyles.None, out dt));
    // Prints True: TryParseExact accepts whitespace, if we tell it to.
    Console.WriteLine(DateTime.TryParseExact(s, "u", null, DateTimeStyles.AllowWhiteSpaces, out dt));
