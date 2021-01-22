    public static bool IsGuid(this string stringValue)
    {
       string guidPattern = @"[a-fA-F0-9]{8}(\-[a-fA-F0-9]{4}){3}\-[a-fA-F0-9]{12}";
       if(string.IsNullOrEmpty(stringValue))
         return false;
       Regex guidRegEx = new Regex(guidPattern);
       return guidRegEx.IsMatch(stringValue);
    }
