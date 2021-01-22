    /// <summary>
    /// Get all files with a specific extension
    /// </summary>
    /// <param name="extensionsToCompare">string list of all the extensions</param>
    /// <param name="Location">string of the location</param>
    /// <returns>array of all the files with the specific extensions</returns>
    public string[] GetFiles(List<string> extensionsToCompare, string Location)
    {
        List<string> files = new List<string>();
        foreach (string file in Directory.GetFiles(Location))
        {
            if (extensionsToCompare.Contains(file.Substring(file.IndexOf('.')+1).ToLower())) files.Add(file);
        }
        files.Sort();
        return files.ToArray();
    }
