    /// <summary>
    /// Searches the specified file for the url and adds it if it doesn't exist.
    /// If the specified file does not exist, it will be created.
    /// </summary>
    /// <param name="filePath">The path to the file to query.</param>
    /// <param name="url">The url to search for and add to the file.</param>
    /// <returns>True if the url was added, otherwise false.</returns>
    protected static bool AddUrlIfNotExist(string filePath, string url)
    {
        if (!File.Exists(filePath)) File.Create(filePath).Close();
        if (!File.ReadLines(filePath).Any(line => line.Contains(url)))
        {
            File.AppendAllText(filePath, url);
            return true;
        }
        return false;
    }
