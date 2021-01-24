    public string NationalitiesPattern;
    public string GetNationalitiesPattern()
    {
        List<string> listOfNationalities = // All valid nationalities.
        string joinedNationalities = string.Join("|", listOfNationalities);
        return $@"\b(?:{joinedNationalities})\b";       // "\b(?:German|Iranian|Qatar|etc)\b"
    }
