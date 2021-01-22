    public static Guid? ParseToNullableGuid(this string stringToParse)
    {
        Guid? val = null;
        
        if(String.IsNullOrEmpty(stringToParse))
            return val;
        var guidPattern = @"[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{8}";
        var validGuid = new Regex(guidPattern, RegexOptions.Compiled);
        if (!validGuid.Match(stringToParse).Success)
            return val;
        try
        {
             val = new Guid(stringToParse);
        }
        catch(FormatException) { }
    
        return val;
    }
