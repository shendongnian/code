        public static void DeleteDirectory(string dir, bool tryAgain = false)
        {
            // If this is a second try, we are going to manually go through and delete the directory 
            if (tryAgain)
            {
                // Interrupt the current thread to allow Explorer time to release a directory handle
                Thread.Sleep(0);
                // Try manually recursing and deleting sub-directories 
                foreach (var d in Directory.GetDirectories(dir))
                    DeleteDirectory(d);
                return;
            }
            try
            {
                // First attempt: use the standard MSDN approach.
                // This fails if a directory is open. 
                Directory.Delete(dir, true);
            }
            catch (IOException)
            {
                DeleteDirectory(dir, true);
            }
            catch (UnauthorizedAccessException)
            {
                DeleteDirectory(dir, true);
            } 
        }
