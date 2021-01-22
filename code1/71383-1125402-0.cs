    public static void WriteAllText(string path, string contents, Encoding encoding)
    {
        using (StreamWriter writer = new StreamWriter(path, false, encoding))
        {
            writer.Write(contents);
        }
    }
