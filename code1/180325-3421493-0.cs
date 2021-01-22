    private void DeleteFiles(DirectoryInfo Directory)
        {
            bool AllFilesDeleted = true;
            foreach(FileInfo oFile in Directory.GetFiles())
            {
                try
                {
                    oFile.Delete();
                }
                catch (Exception ex) { AllFilesDeleted = false; }
            }
            foreach (DirectoryInfo oDirectory in Directory.GetDirectories())
            {
                DeleteFiles(oDirectory);
            }
            if (AllFilesDeleted)
            {
                try
                {
                    Directory.Delete();
                }
                catch (Exception ex){}
            }
        }
