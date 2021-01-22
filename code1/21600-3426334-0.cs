    public static string MakeSafeFilename(string filename, char replaceChar)
    {
        foreach (char c in System.IO.Path.GetInvalidFileNameChars())
        {
            filename = filename.Replace(c, replaceChar);
        }
        return filename;
    }
