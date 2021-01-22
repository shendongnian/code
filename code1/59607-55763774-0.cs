    var files = GetFiles(@"C:\", "*.*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
        Console.WriteLine($"{file}");
    }
    public static IEnumerable<string> GetFiles(string path, string searchPattern, SearchOption searchOption)
    {
        var foldersToProcess = new List<string>()
        {
            path
        };
    
        while (foldersToProcess.Count > 0)
        {
            string folder = foldersToProcess[0];
            foldersToProcess.RemoveAt(0);
    
            if (searchOption.HasFlag(SearchOption.AllDirectories))
            {
                //get subfolders
                try
                {
                    var subfolders = Directory.GetDirectories(folder);
                    foldersToProcess.AddRange(subfolders);
                }
                catch (Exception ex)
                {
                    //log if you're interested
                }
            }
    
            //get files
            var files = new List<string>();
            try
            {
                files = Directory.GetFiles(folder, searchPattern, SearchOption.TopDirectoryOnly).ToList();
            }
            catch (Exception ex)
            {
                //log if you're interested
            }
    
            foreach (var file in files)
            {
                yield return file;
            }
        }
    }
