    public static DirectoryInfo FindFile( DirectoryInfo dir, FileInfo file_name )
                {
                        FileInfo[] files = dir.GetFiles();
                        foreach( FileInfo file in files) {
                            Console.WriteLine("File: {0}", file.Name);
                            Console.WriteLine();
                            if( file.Name == file_name.Name)
                            {
                                 return file.Directory;
                            }
                        }
                        // Search the remaining directories
                        Console.WriteLine("Master dir: {0}", dir.FullName);
                        DirectoryInfo[] sub_dir = dir.GetDirectories();
                        foreach( DirectoryInfo current_dir in sub_dir) {
                             Console.WriteLine("Dir: {0}", current_dir.FullName);
                             Console.WriteLine();
                             var result = FindFile(current_dir, file_name );
                             if (result != null)
                                 return result;
                        }
                        return null;
                }
