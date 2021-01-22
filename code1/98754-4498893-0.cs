        private void directoryCleanup(string root)
        {
            try
            {
                // Create directory "tree"
                ArrayList dirs = new ArrayList();
                // Beginning and ending indexes for each level
                ArrayList levels = new ArrayList();
                int start = 0;
                dirs.Add(root);
                while (start < dirs.Count)
                {
                    ArrayList temp = new ArrayList();
                    for (int i = start; i < dirs.Count; i++)
                    {
                        DirectoryInfo dinfo = new DirectoryInfo((string)dirs[i]);
                        DirectoryInfo[] children = dinfo.GetDirectories();
                        for (int j = 0; j < children.Length; j++)
                        {
                            temp.Add(children[j].FullName);
                        }
                        Array.Clear(children, 0, children.Length);
                        children = null;
                        dinfo = null;
                    }
                    start = dirs.Count;
                    levels.Add(dirs.Count);
                    dirs.AddRange(temp);
                    temp.Clear();
                    temp = null;
                }
                levels.Reverse();
                // Navigate the directory tree level by level, starting with the deepest one
                for (int i = 0; i < levels.Count - 1; i++)
                {
                    int end = (int)levels[i] - 1;
                    int begin = (int)levels[i + 1];
                    for (int j = end; j >= begin; j--)
                    {
                        string path = (string)dirs[j];
                        if (Directory.GetFileSystemEntries(path).Length == 0)
                        {
                            Directory.Delete(path);
                        }
                    }
                }
                levels.Clear();
                levels = null;
                dirs.Clear();
                dirs = null;
            }
            catch (IOException ioex)
            {
                // Manage exception
                return;
            }
            catch (Exception e)
            {
                // Manage exception
                return;
            }
        }
