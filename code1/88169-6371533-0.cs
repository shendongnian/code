    bool HasAccessToWrite(string path)
            {
                try
                {
                    using (FileStream fs = File.Create(Path.Combine(path, "Access.txt"), 1, FileOptions.DeleteOnClose))
                    {
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
