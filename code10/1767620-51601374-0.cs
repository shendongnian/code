     var directories = Directory.GetDirectories("C:\\").OrderByDescending(r => r).ToArray();
            if (directories != null && directories.Length > 0)
            {
                for (int i = 0, Cindex=-1; i < directories.Length; i++)
                {
                    if (Cindex > 0)
                    {
                        Console.WriteLine(directories[i]);
                        continue;
                    }
                    if (directories[i] == "DirectoryC")
                    {
                        Cindex = i;
                    }
                }
            }
