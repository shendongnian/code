    DateTime dt;
    if (DateTime.TryParseExact("28.06.2009", "dd'.'MM'.'yyyy",
                            CultureInfo.InvariantCulture, 
                            DateTimeStyles.None, // Default formatting options
                            out dt))
    {
        Console.WriteLine("Successfully parsed {0}", dt);
    }
    else
    {
        Console.WriteLine("Did not recognise date");
    }
