	static public string ModFileDupilcate(string[] SimsModDownloadDirectory, string[] SimsModsDirectory)
    {
        string NoDuplicateMods = "There are no duplicate mods";
		bool hasDuplicate = false;
        foreach (var ModInDownloadDirectory in SimsModDownloadDirectory)
        {
            foreach (var  ModInModsDirectory in SimsModsDirectory)
            {
                if (ModInDownloadDirectory == ModInModsDirectory)
                {
                    hasDuplicate = true;
					break;
                }
            }
        }
        return hasDuplicate ? "Has duplicates" : NoDuplicateMods;
    }
