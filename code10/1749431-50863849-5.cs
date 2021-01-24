        static void Main(string[] args)
        {
            string sourceDir = @"C:\Src";
            string tempDir = @"C:\Temp";
            string destDir = Path.Combine(sourceDir, "Dest");
            // Could optionally check to verify that the temp directory already exists here and destroy it if it does.
            // Alternatively, pick a really unique name for the temp directory by using a GUID, Thread Id or something of that nature.
            // That way you can be sure it does not already exist.
            // Copy to temp, then destroy source files.
            CopyDirectory(sourceDir, tempDir);
            Directory.Delete(sourceDir, true);
            // Copy to dest
            CopyDirectory(tempDir, destDir);
            // Hide the source directory.
            DirectoryInfo di = new DirectoryInfo(sourceDir);
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            // Clean up the temp directory that way copies of the files aren't sitting around.
            // NOTE: Be sure to do this last as if something goes wrong with the move the temp directory will still exist.
            Directory.Delete(tempDir, true);
        }
        /// <summary>
        /// Recursively copies all subdirectories.
        /// </summary>
        /// <param name="sourceDir">The source directory from which to copy.</param>
        /// <param name="destDir">The destination directory to copy content to.</param>
        static void CopyDirectory(string sourceDir, string destDir)
        {
            var sourceDirInfo = new DirectoryInfo(sourceDir);
            if (!sourceDirInfo.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: '{sourceDir}'");
            }
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }
            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = sourceDirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDir, file.Name);
                file.CopyTo(tempPath, false);
            }
            // Copy subdirectories
            DirectoryInfo[] subDirs = sourceDirInfo.GetDirectories();
            foreach (DirectoryInfo subdir in subDirs)
            {
                string tempPath = Path.Combine(destDir, subdir.Name);
                CopyDirectory(subdir.FullName, tempPath);
            }
        }
