    public void CreateEmptyFile(string path)
    {
        string tempFilePath = Path.Combine(Path.GetDirectoryName(path),
            Guid.NewGuid.ToString());
        using (File.Create(tempFilePath)) {}
        File.Move(tempFilePath, path);
    }
