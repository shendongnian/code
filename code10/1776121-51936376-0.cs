    public static void Rename(string myRootPath)
        {
            string[] myDirectories = Directory.GetDirectories(myRootPath, "*", SearchOption.AllDirectories);
            string[] myDirectoriesModified = new string[myDirectories.Length];
    
            string findFolderNamePattern = @"((?i)domain|.com(?-i))";
            string replacement = "";
    
            int i = 0;
            foreach (var myDirectory in myDirectories)
            {
                myDirectoriesModified[i] = Regex.Replace(myDirectory, findFolderNamePattern, replacement);
                i++;
            }
        }
