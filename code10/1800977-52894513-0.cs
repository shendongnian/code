    public string GetCenturyPrefix(string socSecNo)
    {
        // Check if you're able to parse the incoming value
        // in the format "yyMMdd".
        if (!DateTime.TryParseExact(socSecNo, "yyMMdd", CultureInfo.InvariantCulture, 
            DateTimeStyles.None, out DateTime parsedDateTime))
        {
            // Do something if the input can't be parsed in that format.
            // In this example I'm throwing an exception, but you can also
            // return an empty string.
            throw new Exception("Not valid date format");
        }
        // Extract only the Year portion as a 4 digit string,
        // and return the first 2 characters.
        return parsedDateTime.ToString("yyyy").Substring(0, 2);
    }
