    /* Given a directory path and a datetime,
     * recursively delete all files and directories contained in such directory
     * (given directory included) that are younger than the given date.
     */
    private bool DeleteDirectoryTree(string dir, DateTime keepFilesYoungerThan)
    {
        //checks
        if (String.IsNullOrEmpty(dir) || !Directory.Exists(dir))
            return false;
        //recurse on children directories
        foreach (string childDir in Directory.GetDirectories(dir))
            DeleteDirectoryTree(childDir, keepFilesYoungerThan);
        //loop on children files
        foreach (string file in Directory.GetFiles(dir))
        {
            //calculate file datetime
            DateTime fileDT = new DateTime(Math.Max(File.GetCreationTime(file).Ticks, File.GetLastWriteTime(file).Ticks));
            //if file is old, delete it
            if (fileDT <= keepFilesYoungerThan)
                try
                {
                    File.Delete(file);
                    Log("Deleted file " + file);
                }
                catch (Exception e)
                {
                    LogError("Could not delete file " + file + ", cause: " + e.Message);
                }
        }
        //check if this directory is empty
        if (Directory.GetFileSystemEntries(dir).Length == 0)
        {
            //calculate directory datetime
            DateTime dirDT = new DateTime(Math.Max(Directory.GetCreationTime(dir).Ticks, Directory.GetLastWriteTime(dir).Ticks));
            //if directory is old, delete it
            if (dirDT <= keepFilesYoungerThan)
                try
                {
                    Directory.Delete(dir);
                    Log("Deleted directory " + dir);
                }
                catch (Exception e)
                {
                    LogError("Could not delete directory " + dir + ", cause: " + e.Message);
                }
        }
        return true;
    }
