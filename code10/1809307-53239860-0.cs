    public static List<string> openedFiles = new List<string>();
    public static string ReadFileAndAddToOpenedList(string path)
    {
        if (openedFiles.Contains(path))
            throw new Exception("File already opened");
        else
        {
            openedFiles.Add(path);
            return File.ReadAllText(path);
        }
    }
