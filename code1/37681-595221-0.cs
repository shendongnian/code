    //may return more than 25 characters depending on where in the string 25 characters is at
    public string ShortDescription(string val)
    {
        return Regex.Replace(val, @"(.{25})[^\s]*.*","$1...");
    }
    // stricter version that only returns 25 characters, plus 3 for ...
    public string ShortDescriptionStrict(string val)
    {
        return Regex.Replace(val, @"(.{25}).*","$1...");
    }
