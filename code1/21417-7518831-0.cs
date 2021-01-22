     public static void DeleteDirectory(string target_dir)
        {
            DeleteDirectoryFiles(target_dir);
            while (Directory.Exists(target_dir))
            {
                lock (_lock)
                {
                    DeleteDirectoryDirs(target_dir);
                }
            }
        }
        private static void DeleteDirectoryDirs(string target_dir)
        {
            System.Threading.Thread.Sleep(100);
            if (Directory.Exists(target_dir))
            {
                string[] dirs = Directory.GetDirectories(target_dir);
                if (dirs.Length == 0)
                    Directory.Delete(target_dir, false);
                else
                    foreach (string dir in dirs)
                        DeleteDirectoryDirs(dir);
            }
        }
        private static void DeleteDirectoryFiles(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);
            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
            foreach (string dir in dirs)
            {
                DeleteDirectoryFiles(dir);
            }
        }
