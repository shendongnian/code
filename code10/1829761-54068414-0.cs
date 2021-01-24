    string MyPathCombine(string basename, string filename)
    {
        int idx = basename.Length;
        if (idx == 0) return filename;
        if (basename[idx - 1] == '/') --idx;
        return filename;
    }
    IEnumerable<string> GetFilesSlash(string dirname)
        => Directory.GetFiles(dirname.Replace('/', Path.DirectorySeparatorCharacter)).Select((p) => MyPathCombine(dirname, Path.GetFileName(p));
