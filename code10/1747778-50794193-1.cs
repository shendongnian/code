     public static void CreateFile(string location)
                {
                    var fileInfo = new FileInfo(location);
                    try
                    {
                        // Delete the file if it exists.
                        if (fileInfo.Exists)
                        {
                            fileInfo.Delete();
                        }
                        // Create the file and directory.
                  if (!Directory.Exists(fileInfo.DirectoryName))
                        Directory.CreateDirectory(fileInfo.DirectoryName);
                
            
                        fileInfo.Create();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
