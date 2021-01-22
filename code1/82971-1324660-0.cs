    string countryCode = "de";
    try {
        RegionInfo info = new RegionInfo(countryCode);
    }
    catch (ArgumentException argEx)
    {
        // The code was not a valid country code
    }
