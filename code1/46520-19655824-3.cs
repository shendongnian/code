    public static Boolean Fits(string sFileName, string sFileMask)
    {
        String convertedMask = "^" + Regex.Escape(sFileMask).Replace("\\*", ".*").Replace("\\?", ".") + "$";
        Regex regexMask = new Regex(convertedMask, RegexOptions.IgnoreCase);
        return regexMask.IsMatch(sFileName)
    }
