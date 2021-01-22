    private void AddFavorites(string dirPath)
    {
        try
            {
                foreach (string fileName in Directory.GetFiles(dirPath, "*.*", SearchOption.TopDirectoryOnly))
                {
                    //string alias = fileInfo.Name.Replace(".url", "");
                    if (!ItemsBookmarks.ContainsKey(fileInfo.Name))
                    {
                        ItemsBookmarks.Add(fileName);
                    }
                }
                foreach (string subDirName in Directory.GetDirectories(dirPath, "*.*", SearchOption.TopDirectoryOnly))
                {
                    AddFavorites(objDir);
                }
            }
            catch
            {
                //error getting files or subdirs... permissions issue?
                //throw
            }
    }
