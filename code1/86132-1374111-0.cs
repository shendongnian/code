                DateTime CutOffDate = DateTime.Now.AddDays(-4)
                DirectoryInfo di = new DirectoryInfo(folderPath);
                FileInfo[] fi = di.GetFiles();
                for (int i = 0; i < fi.Length; i++)
                {
                    if (fi[i].LastWriteTime < CutOffDate)
                    {
                        File.Delete(fi[i].FullName);
                    }
                }
