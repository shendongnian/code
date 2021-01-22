                system.IO;
                
                 List<string> DeletePath = new List<string>();
                DirectoryInfo info = new DirectoryInfo(Server.MapPath("~\\TempVideos"));
                FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                foreach (FileInfo file in files)
                {
                    DateTime CreationTime = file.CreationTime;
                    double days = (DateTime.Now - CreationTime).TotalDays;
                    if (days > 7)
                    {
                        string delFullPath = file.DirectoryName + "\\" + file.Name;
                        DeletePath.Add(delFullPath);
                    }
                }
                foreach (var f in DeletePath)
                {
                    if (File.Exists(F))
                    {
                        File.Delete(F);
                    }
                }
