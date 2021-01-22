        public static void ProcessDirectories(DirectoryInfo dirInput, string dirOutput)
        {
            DirectoryInfo[] dirs = dirInput.GetDirectories();
            string dirOutputfix = String.Empty;
            foreach (DirectoryInfo di in dirInput.GetDirectories())
            {
                dirOutputfix = dirOutput + "\\" + Path.GetFileName(di.FullName);
                if (!Directory.Exists(dirOutputfix))
                {
                    try
                    {
                        Directory.CreateDirectory(dirOutputfix);
                    }
                    catch(Exception e)
                    {
                        throw (e);
                    }
                }
                ProcessDirectories(di, dirOutputfix);
            }
        }
