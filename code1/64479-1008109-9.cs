    // Put this in a non-nested static class
    public static string ToBriefName(this Country country) 
    {
        string name;
        return (CountryNames.TryGetValue(country, out name))
            ? name : country.ToString();
    }
