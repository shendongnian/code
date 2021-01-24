        public static IEnumerable<string> GetAllAccessibleFilesIn(string rootDirectory, string searchPattern = "*.*")
        {
            foreach (string file in Directory.EnumerateFiles(rootDirectory, "*.*", SearchOption.AllDirectories))
            {
                bool isSystemFile = (File.GetAttributes(file) & FileAttributes.System) != 0;
                try
                {
                    if (HasFolderWritePermission(file) && !isSystemFile)
                    {
                        Console.WriteLine(file);
                        using (var stream = File.OpenRead(file))
                        {
                            // I am checking file here  with my own functions.
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    //User cannot access directory
                    Console.WriteLine("I AM NOT CONTINUING " + ex.Message);
                }
                catch (System.Exception excpt)
                {
                    // Console.WriteLine("I AM AN ERROR!!!\n");
                    Console.WriteLine(excpt.Message);
                }
            }
        }
