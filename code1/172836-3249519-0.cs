    static void SanitizeFolders(DirectoryInfo root)
    {
        string regPattern = (@"[~#&!%+{}]+");
        string cleanName = "";
        Regex regExPattern = new Regex(regPattern);
        foreach (DirectoryInfo sub in root.GetDirectories())
        {
            if (regExPattern.IsMatch(sub.Name))
            {
                /* set cleanName appropriately... */
                sub.MoveTo(cleanName);
            }
        }
        //recurse into subdirectories
        foreach (DirectoryInfo sub in root.GetDirectories())
        {
            SanitizeFolders(sub);
        }
    }
