    static public List<string> ModFileDupilcate(string[] SimsModDownloadDirectory, string[] SimsModsDirectory)
    {
		var duplicateDirs = new List<string>();
		
        foreach (var ModInDownloadDirectory in SimsModDownloadDirectory)
        {
            foreach (var  ModInModsDirectory in SimsModsDirectory)
            {
                if (ModInDownloadDirectory == ModInModsDirectory)
                {
                    duplicateDirs.Add(ModInModsDirectory);
                }
            }
        }
        return duplicateDirs;
    }
