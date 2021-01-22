    internal static string GetWindowsPath(string p_fileName)
        {
            string path = null;
            string sysdir;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    if (i == 0)
                    {
                        path = Environment.GetEnvironmentVariable("SystemRoot");
                    }
                    else if (i == 1)
                    {
                        path = Environment.GetEnvironmentVariable("windir");
                    }
                    else if (i == 2)
                    {
                        sysdir = Environment.GetFolderPath(Environment.SpecialFolder.System);
                        path = System.IO.Directory.GetParent(sysdir).FullName;
                    }
                    if (path != null)
                    {
                        path = System.IO.Path.Combine(path, p_fileName);
                        if (System.IO.File.Exists(path) == true)
                        {
                            return path;
                        }
                    }
                }
                catch { }
            }
            // not found
            return null;
        }
