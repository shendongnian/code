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
                        // Create the file.
                        fileInfo.Create();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
