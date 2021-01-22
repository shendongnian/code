    public int GetNextIdFromFileNames(string path, string filePattern, string regexPattern)
    {
        // get all the file names
        string[] files = Directory.GetFiles(path, filePattern, SearchOption.TopDirectoryOnly);
        
        // extract the ID from every file, get the highest ID and return it + 1
        return ExtractIdsFromAssemblyList(files, regexPattern).Max() + 1;
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
                if (int.TryParse(match.Groups[1].Value, out value))
                {
                    yield return value;
                }
            }
        }
    }
