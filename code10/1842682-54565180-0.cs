    public void DeleteContents(DirectoryInfo directoryInfo, bool removeSubFolders = false)
    {
        foreach (var file in directoryInfo.GetFiles())
        {
            file.Delete();
        }
        if (removeSubFolders)
        {
            foreach (var subDirectory in directoryInfo.GetDirectories())
            {
                subDirectory.Delete(true);
            }
        }
    }
