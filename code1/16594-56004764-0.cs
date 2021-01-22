    public static bool IsFileLocked(string filename)
            {
                bool Locked = false;
                try
                {
                    FileStream fs =
                        File.Open(filename, FileMode.OpenOrCreate,
                        FileAccess.ReadWrite, FileShare.None);
                    fs.Close();
                }
                catch (IOException ex)
                {
                    Locked = true;
                }
                return Locked;
            }
