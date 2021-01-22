    public static void WriteFile(string fileName, Stream inputStream)
    {
        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!path.EndsWith(@"\")) path += @"\";
        if (File.Exists(Path.Combine(path, fileName)))
            File.Delete(Path.Combine(path, fileName));
        using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.CreateNew, FileAccess.Write)
        {
            CopyStream(inputStream, fs);
            fs.Close();
        }
    }
