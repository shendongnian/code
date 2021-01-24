    private bool DirectoryModificationTimeEquals(string pathA, string pathB)
    {
        var directoryA = new DirectoryInfo(pathA);
        var directoryB = new DirectoryInfo(pathB);
        var filesA = directoryA.GetFiles().OrderBy(x => x.Name).ToList();
        var filesB = directoryB.GetFiles().OrderBy(x => x.Name).ToList();
        if (filesA.Count == filesB.Count)
        {
            for (int i = 0; i < filesA.Count; i++)
            {
                if (!filesA[i].Name.Equals(filesB[i].Name))
                {
                    return false;
                }
                if (filesA[i].LastWriteTime != filesB[i].LastWriteTime)
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
