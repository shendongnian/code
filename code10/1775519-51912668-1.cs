		static public string ModFileDupilcate(string[] SimsModDownloadDirectory, string[] SimsModsDirectory)
    {
        string NoDuplicateMods = "There are no duplicate mods";
        foreach (var ModInDownloadDirectory in SimsModDownloadDirectory)
        {
            foreach (var  ModInModsDirectory in SimsModsDirectory)
            {
                if (ModInDownloadDirectory == ModInModsDirectory)
                {
					return ModInModsDirectory;
                }
            }
        }
        return NoDuplicateMods;
    }
