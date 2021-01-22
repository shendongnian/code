    public void DeleteFiles(string path, string toDelete)
        {
            if(Directory.Exists(path))
            {
                foreach(string folder in Directory.GetDirectories(path))
                {
                    if(toDelete == Path.GetDirectoryName(folder))
                    {
                        DeleteFilesInFolder(folder);
                        Directory.Delete(folder);
                    }
                }
            }
        }
