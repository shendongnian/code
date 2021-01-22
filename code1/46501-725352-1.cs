    private bool Fits(string sFileName, string sFileMask)
    {
        RegEx mask = new RegEx(sFileMask.Replace(".", "[.]").Replace("*", ".*").Replace("?", "."));
        return mask.IsMatch(sFileName);
    }
