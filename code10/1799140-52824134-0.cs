    /// <summary>
    /// Moves all files in mainFolder to a subfolder based on the file's name
    /// </summary>
    /// <param name="mainFolder">The root folder to scan for files</param>
    /// <returns>true if the operation was successful</returns>
    public static bool OrganizeFiles(string mainFolder)
    {
        if (!Directory.Exists(mainFolder)) 
            throw new DirectoryNotFoundException(nameof(mainFolder));
        try
        {
            foreach (var file in Directory.EnumerateFiles(mainFolder))
            {
                var subFolderName = Path.GetFileNameWithoutExtension(file);
                var lastHyphen = subFolderName.LastIndexOf("-");
                if (lastHyphen > -1)
                {
                    subFolderName = subFolderName.Substring(0, lastHyphen);
                }
                Directory.CreateDirectory(Path.Combine(mainFolder, subFolderName));
                File.Move(file, subFolderName);
            }
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
