    public void DeleteContents(DirectoryInfo directoryInfo, bool includeSubFolders = false)
    {
        foreach (var file in directoryInfo.GetFiles())
        {
            file.Delete();
        }
        if (includeSubFolders)
        {
            foreach (var subDirectory in directoryInfo.GetDirectories())
            {
                subDirectory.Delete(true);
            }
        }
    }
