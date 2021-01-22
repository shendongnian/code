    public int GetNextIdFromFileNames(string path, string filePattern, string regexPattern)
    {
        // get all the file names
        string[] files = Directory.GetFiles(path, filePattern, SearchOption.TopDirectoryOnly);
        
        // extract the ID from every file
        List<int> ids = ExtractIdsFromFileList(files, regexPattern).ToList();
        // sort by ID ascending
        ids.Sort();
        // take the last (highest) ID and add 1
        return ids[ids.Count - 1] + 1;
    }
    private IEnumerable<int> ExtractIdsFromFileList(string[] files, string regexPattern)
    {
        Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
        foreach (string file in files)
        {
            Match match = regex.Match(file);
            if (match.Success)
            {
                int value;
                if (int.TryParse(match.Groups[0].Value, out value))
                {
                    yield return value;
                }
            }
        }
    }
