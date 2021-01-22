        /// <summary>
        /// Depth-first recursive delete, with handling for descendant 
        /// directories open in Windows Explorer.
        /// </summary>
        public static void DeleteDirectory(string path)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                Thread.Sleep(1);
                DeleteDir(directory);
            }
            DeleteDir(path);
        }
        private static void DeleteDir(string dir)
        {
            try
            {
                Thread.Sleep(1);
                Directory.Delete(dir, true);
            }
            catch (IOException)
            {
                DeleteDir(dir);
            }
            catch (UnauthorizedAccessException)
            {
                DeleteDir(dir);
            }
        }
