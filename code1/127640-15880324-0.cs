     public void Empty(System.IO.DirectoryInfo directory)
            {
                try
                {
                    logger.DebugFormat("Empty directory {0}", directory.FullName);
                    foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                    foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
                }
                catch (Exception ex)
                {
                    ex.Data.Add("directory", Convert.ToString(directory.FullName, CultureInfo.InvariantCulture));
                  
                    throw new Exception(string.Format(CultureInfo.InvariantCulture,"Method:{0}", ex.TargetSite), ex);
                }
            }
