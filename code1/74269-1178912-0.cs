    public static string GetNextFilename(this string filename)
    {
        int i = 1;
        string dir = Path.GetDirectoryName(filename);
        string file = Path.GetFileNameWithoutExtension(filename) + "{0}";
        string extension = Path.GetExtension(filename);
        while (File.Exists(filename))
            filename = Path.Combine(dir, string.Format(file, "(" + i++ + ")") + extension);
        return filename;
    }
