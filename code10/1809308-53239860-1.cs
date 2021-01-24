    public static List<string> openedFiles = new List<string>();
    public static string ReadFileAndAddToOpenedList(string path)
    {
        if (openedFiles.Contains(path))
            throw new Exception("File already opened");
            // Instead of throwing exception you could for example just log this or do something else, like:
            // Consolle.WriteLine("File already opened");
        else
        {
            openedFiles.Add(path);
            return File.ReadAllText(path);
        }
    }
