    public static IEnumerable<string> GetFileList(string fileSearchPattern, string rootFolderPath)
    {
        Queue<string> pending = new Queue<string>();
        pending.Enqueue(rootFolderPath);
        string[] tmp;
        while (pending.Count > 0)
        {
            rootFolderPath = pending.Dequeue();
            try
            {
                tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);
            }
            catch (UnauthorizedAccessException)
            {
                continue;
            }
            for (int i = 0; i < tmp.Length; i++)
            {
                yield return tmp[i];
            }
            tmp = Directory.GetDirectories(rootFolderPath);
            for (int i = 0; i < tmp.Length; i++)
            {
                pending.Enqueue(tmp[i]);
            }
        }
    }
