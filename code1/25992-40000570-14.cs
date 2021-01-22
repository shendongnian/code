    public static void WriteFile(string fileName, byte[] bytes)
    {
        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!path.EndsWith(@"\")) path += @"\";
        if (File.Exists(Path.Combine(path, fileName)))
            File.Delete(Path.Combine(path, fileName));
        using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.CreateNew, FileAccess.Write))
        {
            fs.Write(bytes, 0, (int)bytes.Length);
            fs.Close();
        }
    }
