     public void removeReadOnlyDeep(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            foreach (string file in files)
            {
                FileAttributes attributes = File.GetAttributes(file);
                if ((attributes & FileAttributes.ReadOnly) != 0)
                {
                    File.SetAttributes(file, ~FileAttributes.ReadOnly);
                }
            }
            string[] dirs = Directory.GetDirectories(directory);
            foreach (string dir in dirs)
            {
                removeReadOnlyDeep(dir);
            }
        }
