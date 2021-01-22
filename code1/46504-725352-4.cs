    private bool FitsMask(string sFileName, string sFileMask)
    {
        Regex mask = new Regex(sFileMask.Replace(".", "[.]").Replace("*", ".*").Replace("?", "."));
        return mask.IsMatch(sFileName);
    }
