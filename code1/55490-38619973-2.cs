    public static List<Process> GetProcessesLockingFile(FileInfo file)
    {
        var procs = new List<Process>();
        var processListSnapshot = Process.GetProcesses();
        foreach (var process in processListSnapshot)
        {
            if (process.Id <= 4) { continue; } // system processes
            
            List<string> paths = GetFilesLockedBy(process);
            foreach (string path in paths)
            {
                string pathDirectory = path;
                if (!pathDirectory.EndsWith(Constants.DOUBLE_BACKSLASH))
                {
                    pathDirectory = pathDirectory + Constants.DOUBLE_BACKSLASH;
                }
                string lastFolderName = Path.GetFileName(Path.GetDirectoryName(pathDirectory));
                if (file.FullName.Contains(lastFolderName))
                {
                    procs.Add(process);
                }
            }
        }
        return procs;
    }
