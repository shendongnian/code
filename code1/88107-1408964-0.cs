       if (System.IO.File.Exists(path))
                {
                    System.IO.FileInfo info = new System.IO.FileInfo(path);
                    System.IO.File.SetAttributes(info.FullName,     
                                           System.IO.FileAttributes.Normal);
                    System.IO.File.Delete(info.FullName);
                }
