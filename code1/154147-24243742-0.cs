        private static void deleteEmptySubFolders(string ffd, bool deleteIfFileSizeZero=false)
    {
        DirectoryInfo di = new DirectoryInfo(ffd);
        foreach (DirectoryInfo diSon in di.GetDirectories("*", SearchOption.TopDirectoryOnly))
        {
            FileInfo[] fis = diSon.GetFiles("*.*", SearchOption.AllDirectories);
            if (fis == null || fis.Length < 1)
            {
                diSon.Delete(true);
            }
            else
            {
                if (deleteIfFileSizeZero)
                {
                    long total = 0;
                    foreach (FileInfo fi in fis)
                    {
                        total = total + fi.Length;
                        if (total > 0)
                        {
                            break;
                        }
                    }
    
                    if (total == 0)
                    {
                        diSon.Delete(true);
                        continue;
                    }
                }
    
                deleteEmptySubFolders(diSon.FullName, deleteIfFileSizeZero);
            }
        }
    }
