     public static string FindFile(DirectoryInfo folder, string fileName)
            {
                if (folder.GetFiles().Where(x => x.Name == fileName).ToArray().Length > 0)
                {
                    return folder.FullName;
                }
    
                foreach (var newFolder in folder.GetDirectories())
                {
                    return FindFile(newFolder, fileName);
                }
    
                return "Nothing found";
            }
