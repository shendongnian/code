        public static void DeleteDirectory(string dir, bool tryAgain = false)
        {
            // If this is a second try, we are going to manually 
            // delete the files and sub-directories. 
            if (tryAgain)
            {
                // Interrupt the current thread to allow Explorer time to release a directory handle
                Thread.Sleep(0);
                
                // Delete any files in the directory 
                foreach (var f in Directory.GetFiles(dir, "*.*", SearchOption.TopDirectoryOnly))
                    File.Delete(f);
                // Try manually recursing and deleting sub-directories 
                foreach (var d in Directory.GetDirectories(dir))
                    DeleteDirectory(d);
                // Now we try to delete the current directory
                Directory.Delete(dir, false);
                return;
            }
            try
            {
                // First attempt: use the standard MSDN approach.
                // This will throw an exception a directory is open in explorer
                Directory.Delete(dir, true);
            }
            catch (IOException)
            {
                // Try again to delete the directory manually recursing. 
                DeleteDirectory(dir, true);
            }
            catch (UnauthorizedAccessException)
            {
                // Try again to delete the directory manually recursing. 
                DeleteDirectory(dir, true);
            } 
        }
