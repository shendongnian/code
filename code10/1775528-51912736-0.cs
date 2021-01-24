    static public bool ModFileDupilcate(string[] SimsModDownloadDirectory, List<string> SimsModsDirectory,out List<string> dublicatedFiles)
        {
            dublicatedFiles = new List<string>();
            foreach (var ModInDownloadDirectory in SimsModDownloadDirectory)
            {
                foreach (var  ModInModsDirectory in SimsModsDirectory)
                {
                    if (ModInDownloadDirectory == ModInModsDirectory)
                    {   
                        dublicatedFiles.Add(ModInModsDirectory);
                    }
                }
            }
            return dublicatedFiles.Count > 0;
        }
