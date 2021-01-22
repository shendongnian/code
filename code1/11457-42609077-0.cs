    /// <summary>
    /// Matches files from folder _dir using glob file pattern.
    /// In glob file pattern matching * reflects to any file or folder name, ** refers to any path (including sub-folders).
    /// ? refers to any character.
    /// 
    /// There exists also 3-rd party library for performing similar matching - 'Microsoft.Extensions.FileSystemGlobbing'
    /// but it was dragging a lot of dependencies, I've decided to survive without it.
    /// </summary>
    /// <returns>List of files matches your selection</returns>
    static public String[] matchFiles( String _dir, String filePattern )
    {
        if (filePattern.IndexOfAny(new char[] { '*', '?' }) == -1)      // Speed up matching, if no asterisk / widlcard, then it can be simply file path.
        {
            String path = Path.Combine(_dir, filePattern);
            if (File.Exists(path))
                return new String[] { filePattern };
            return new String[] { };
        }
        String dir = Path.GetFullPath(_dir);        // Make it absolute, just so we can extract relative path'es later on.
        String[] pattParts = filePattern.Replace("/", "\\").Split('\\');
        List<String> scanDirs = new List<string>();
        scanDirs.Add(dir);
        //
        //  By default glob pattern matching specifies "*" to any file / folder name, 
        //  which corresponds to any character except folder separator - in regex that's "[^\\]*"
        //  glob matching also allow double astrisk "**" which also recurses into subfolders. 
        //  We split here each part of match pattern and match it separately.
        //
        for (int iPatt = 0; iPatt < pattParts.Length; iPatt++)
        {
            bool bIsLast = iPatt == (pattParts.Length - 1);
            bool bRecurse = false;
            String regex1 = Regex.Escape(pattParts[iPatt]);         // Escape special regex control characters ("*" => "\*", "." => "\.")
            String pattern = Regex.Replace(regex1, @"\\\*(\\\*)?", delegate (Match m)
                {
                    if (m.ToString().Length == 4)   // "**" => "\*\*" (escaped) - we need to recurse into sub-folders.
                    {
                        bRecurse = true;
                        return ".*";
                    }
                    else
                        return @"[^\\]*";
                }).Replace(@"\?", ".");
            if (pattParts[iPatt] == "..")                           // Special kind of control, just to scan upper folder.
            {
                for (int i = 0; i < scanDirs.Count; i++)
                    scanDirs[i] = scanDirs[i] + "\\..";
                
                continue;
            }
                
            Regex re = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            int nScanItems = scanDirs.Count;
            for (int i = 0; i < nScanItems; i++)
            {
                String[] items;
                if (!bIsLast)
                    items = Directory.GetDirectories(scanDirs[i], "*", (bRecurse) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                else
                    items = Directory.GetFiles(scanDirs[i], "*", (bRecurse) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                foreach (String path in items)
                {
                    String matchSubPath = path.Substring(scanDirs[i].Length + 1);
                    if (re.Match(matchSubPath).Success)
                        scanDirs.Add(path);
                }
            }
            scanDirs.RemoveRange(0, nScanItems);    // Remove items what we have just scanned.
        } //for
        //  Make relative and return.
        return scanDirs.Select( x => x.Substring(dir.Length + 1) ).ToArray();
    } //matchFiles
