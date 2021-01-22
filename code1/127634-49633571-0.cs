    static void CleanBackupFiles()
            {
                string gstrUncFolder = ConfigurationManager.AppSettings["DropFolderUNC"] + "";
                int iDelAge = Convert.ToInt32(ConfigurationManager.AppSettings["NumDaysToKeepFiles"]) * -1;
                string backupdir = string.Concat(@"\", "Backup", @"\");
    
                string[] files = Directory.GetFiles(string.Concat(gstrUncFolder, backupdir));
                
    
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.CreationTime < DateTime.Now.AddDays(iDelAge))
                    {
                        fi.Delete();
                    }
                }
    
            }
