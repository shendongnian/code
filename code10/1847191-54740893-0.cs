    private static void GenerateNewFile(string sourceFullPath)
    {
        string posData = null;
        string refData = null;
        string fullData = null;
        var modCodeBuilder = new StringBuilder();
        var extCodeBuilder = new StringBuilder();
        var extrRegex = new Regex(@"\bExtr\(-?\d*.\d*\);", RegexOptions.Compiled | 
            RegexOptions.IgnoreCase | RegexOptions.Multiline);
        var moveLRegex = new Regex(@"\bMoveL\s+(.*)(z\d.*)", RegexOptions.Compiled | 
            RegexOptions.IgnoreCase | RegexOptions.Multiline);
        int matchCount = 0;
        bool appendModCodeNext = false;
        foreach (var line in File.ReadLines(sourceFullPath))
        {
            if (appendModCodeNext)
            {
                if (moveLRegex.IsMatch(line))
                {
                    GroupCollection group = moveLRegex.Match(line).Groups;
                    if (group.Count > 2)
                    {
                        posData = group[1].Value;
                        refData = group[2].Value;
                        fullData = posData + refData;
                    }
                }
                modCodeBuilder.AppendLine(string.Concat("\t\tTriggL ", posData, "extr,", refData,
                    "\r\n\t\tWaitDI DI1_1,1;\r\n\t\tMoveL ", fullData, "\r\n\t\tReset DO1_1;"));
                appendModCodeNext = false;
            }
            else if (extrRegex.IsMatch(line))
            {
                matchCount++;
                extCodeBuilder.AppendLine($"\t\t{extrRegex.Match(line)}");
                appendModCodeNext = true;
            }
            else
            {
                modCodeBuilder.AppendLine(line);
            }
        }
        Console.WriteLine($"Total Matches: {matchCount}");
        string destDir = Path.GetDirectoryName(sourceFullPath);
        var savePath = Path.Combine(destDir, Path.GetFileNameWithoutExtension(sourceFullPath), 
            "_rev.mod");
        File.WriteAllText(savePath, modCodeBuilder.ToString());
        var extCallMod = string.Concat("MODULE ExtruderCalls\r\n\r\n\tPROC Prg_ExtCall",
            extCodeBuilder.ToString(), "\r\n\r\n\tENDPROC\r\n\r\nENDMODULE");
        File.WriteAllText(Path.Combine(destDir, "ExtrCalls.mod"), extCallMod);
    }
