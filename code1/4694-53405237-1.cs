    public static void CopyEntireDirectory(string path, string newPath)
    {
        Parallel.ForEach(Directory.GetFileSystemEntries(path, "*", SearchOption.AllDirectories)
    	,(fileName) =>
        {
            string output = Regex.Replace(fileName, "^" + Regex.Escape(path), newPath);
            if (File.Exists(fileName))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(output));
                File.Copy(fileName, output, true);
            }
            else
                Directory.CreateDirectory(output);
        });
    }
