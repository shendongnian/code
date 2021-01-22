    public static void WorkWithFile(string filename, Action<FileStream> action)
    {
        using (FileStream stream = File.OpenRead(filename))
        {
            action(stream);
        }
    }
