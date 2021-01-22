    public static class DirectoryInfoExtensions
    {
        // Copies all files from one directory to another.
        public static void CopyTo(this DirectoryInfo source, 
                string destDirectory, bool recursive)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (destDirectory == null)
                throw new ArgumentNullException("destDirectory");
            // If the source doesn't exist, we have to throw an exception.
            if (!source.Exists)
                throw new DirectoryNotFoundException(
                        "Source directory not found: " + source.FullName);
            // Compile the target.
            DirectoryInfo target = new DirectoryInfo(destDirectory);
            // If the target doesn't exist, we create it.
            if (!target.Exists)
                target.Create();
            // Get all files and copy them over.
            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }
            // Return if no recursive call is required.
            if (!recursive)
                return;
            // Do the same for all sub directories.
            foreach (DirectoryInfo directory in source.GetDirectories())
            {
                CopyTo(directory, 
                    Path.Combine(target.FullName, directory.Name), recursive);
            }
        }
    }
    
