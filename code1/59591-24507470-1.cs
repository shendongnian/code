     static DirOrFileModel DirSearch(DirOrFileModel startDir)
            {
                var currentDir = startDir;
                try
                {
                    foreach (string d in Directory.GetDirectories(currentDir.Location))
                    {
                        var newDir = new DirOrFileModel
                        {
                            EntryType = EntryType.Directory,
                            Location = d,
                            Name = Path.GetFileName(d)
                        };
                        currentDir.Entries.Add(newDir);
    
                        DirSearch(newDir);
                    }
    
                    foreach (string f in Directory.GetFiles(currentDir.Location))
                    {
                        var newFile = new DirOrFileModel
                        {
                            EntryType = EntryType.File,
                            Location = f,
                            Name = Path.GetFileNameWithoutExtension(f)
                        };
                        currentDir.Entries.Add(newFile);
                    }
    
                }
                catch (Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                }
                return startDir;
            }
