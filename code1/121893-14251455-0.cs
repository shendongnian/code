        private void SortFiles(FileSystemInfo[] oFiles)
        {
            FileSystemInfo oFileInfo = null;
            int i = 0;
            while (i + 1 < oFiles.Length)
            {
                if (string.Compare(oFiles[i].Name, oFiles[i + 1].Name) > 0)
                {
                    oFileInfo = oFiles[i];
                    oFiles[i] = oFiles[i + 1];
                    oFiles[i + 1] = oFileInfo;
                    if (i > 0)
                    {
                        i--;
                    }
                }
                else
                {
                    i++;
                }
            }
        }
