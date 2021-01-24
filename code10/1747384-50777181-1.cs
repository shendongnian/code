     string newFolder = "NewlyAdded";
                string path = System.IO.Path.Combine(
                   Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                   newFolder
                );
    
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                 }
                        var directory = new DirectoryInfo(@"Sourcd folder");
                var myFile = (from f in directory.GetFiles()
                              orderby f.LastWriteTime descending
                              select f).First();
                Console.WriteLine(Path.GetFileName(myFile.Name));
                string destFile = Path.Combine(path, myFile.Name);
                System.IO.File.Copy(myFile.FullName, destFile, true);
