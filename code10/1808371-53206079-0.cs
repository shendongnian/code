    string text = "21:05";
    string format = "HH:mm";
    CultureInfo invariant = System.Globalization.CultureInfo.InvariantCulture;
    DateTime dt;
    if (DateTime.TryParseExact(text, format, invariant, DateTimeStyles.None, out dt))
    {
    // do your stuff
    }
    else
    {
    // handle the fact you cannot parse the datetime
    }
