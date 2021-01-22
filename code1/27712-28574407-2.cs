        public static void ProcessDirectories(DirectoryInfo dirInput, string dirOutput)
        {
            string dirOutputfix = String.Empty;
            foreach (DirectoryInfo di in dirInput.GetDirectories())
            {
                dirOutputfix = dirOutput + "\\" + di.Name);
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
