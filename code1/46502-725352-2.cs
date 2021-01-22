    private bool Fits(string sFileName, string sFileMask)
    {
        Regex mask = new Regex(sFileMask.Replace(".", "[.]").Replace("*", ".*").Replace("?", "."));
        return mask.IsMatch(sFileName);
    }
