    public void AppendToFile(Guid id, string fileName, Stream content)
    {
        CreateDirectory(id);
        string dirPath = Path.Combine(RootDiectory, id.ToString());
        string fullPath = Path.Combine(dirPath, fileName);
        Protected(id, () =>
        {
            using (FileStream stream = new FileStream(fullPath, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                using (content)
                {
                    content.CopyTo(stream);
                }
            }
        });
    }
    
    public void DeleteFile(Guid id, string fileName)
    {
        string path = Path.Combine(RootDiectory, id.ToString(), fileName);
        Protected(id, () =>
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            string dirPath = Path.Combine(RootDiectory, id.ToString());
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            if (dir.Exists && !dir.GetFiles().Any())
            {
                Directory.Delete(dirPath, false);
            }
        });
    }
