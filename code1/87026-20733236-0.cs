    public static List<string> GetAllAccessibleFiles(string rootPath, List<string> alreadyFound = null)
        {
            if (alreadyFound == null)
                alreadyFound = new List<string>();
            DirectoryInfo di = new DirectoryInfo(rootPath);
            var dirs = di.EnumerateDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                if (!((dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                {
                    alreadyFound = GetAllAccessibleFiles(dir.FullName, alreadyFound);
                }
            }
            var files = Directory.GetFiles(rootPath);
            foreach (string s in files)
            {
                alreadyFound.Add(s);                
            }
            return alreadyFound;
        }
