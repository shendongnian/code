    protected bool isDirectoryFound(string path, string pattern)
        {
            bool success = false;
    
            DirectoryInfo directories = new DirectoryInfo(@path);
            DirectoryInfo[] folderList = directories.GetDirectories();
    
            Regex rx = new Regex(pattern);
    
            foreach (DirectoryInfo di in folderList)
            {
                if (rx.IsMatch(di.Name))
                {
                    success = true;
                    break;
                }
            }
    
            return success;
        }
