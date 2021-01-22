    /// <summary>
    /// Replaces each occurrence of sPattern in sInput with sReplace. This is done 
    /// with the CLR: 
    /// new RegEx(sPattern, RegexOptions.Multiline).Replace(sInput, sReplace). 
    /// The result of the replacement is the return value.
    /// </summary>
    [SqlFunction(IsDeterministic = true)]
    [return: SqlFacet(MaxSize = -1)]
    public static  SqlString FRegexReplace([SqlFacet(MaxSize = -1)]string sInput, 
           string sPattern, string sReplace)
    {
        return new Regex(sPattern, RegexOptions.Multiline).Replace(sInput, sReplace);
    }
