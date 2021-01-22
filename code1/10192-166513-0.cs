    public static string ReadAllText(string path, Encoding encoding)
    {
        using (StreamReader reader = new StreamReader(path, encoding))
        {
            return reader.ReadToEnd();
        }
    }
