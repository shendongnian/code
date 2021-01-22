     public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
     {
        List<String> filesFound = new List<String>();
        var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        foreach (var filter in filters)
        {
           filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption))
        }
        return filesFound.ToArray();
     }
