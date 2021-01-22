    private void DeleteRecursiveFolder(string pFolderPath)
    {
        foreach (string Folder in Directory.GetDirectories(pFolderPath))
        {
            DeleteRecursiveFolder(Folder);
        }
        foreach (string file in Directory.GetFiles(pFolderPath))
        {
            var pPath = Path.Combine(pFolderPath, file);
            FileInfo fi = new FileInfo(pPath);
            File.SetAttributes(pPath, FileAttributes.Normal);
            File.Delete(file);
        }
        Directory.Delete(pFolderPath);
    }
