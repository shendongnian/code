    private bool FitsMask(string fileName, string fileMask)
    {
        Regex mask = new Regex(
            '^' + 
            fileMask
                .Replace(".", "[.]")
                .Replace("*", ".*")
                .Replace("?", ".")
            + '$',
            RegexOptions.IgnoreCase);
        return mask.IsMatch(fileName);
    }
