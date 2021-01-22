    string language = "de";
    string countryCode = "de";
    try {
        RegionInfo info = new RegionInfo(string.Format("{0}-{1}", language, countryCode));
    }
    catch (ArgumentException argEx)
    {
        // The code was not a valid country code for the specified language
    }
