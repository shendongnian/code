    private bool ProgramIsRunning(string FullPath)
    {
        string FilePath =  Path.GetDirectoryName(FullPath);
        string FileName = Path.GetFileNameWithoutExtension(FullPath).ToLower();
        bool isRunning = false;
    
        Process[] pList = Process.GetProcessesByName(FileName);
        
        foreach (Process p in pList) {
            if (p.MainModule.FileName.StartsWith(FilePath, StringComparison.InvariantCultureIgnoreCase))
            {
                isRunning = true;
                break;
            }
        }
    
        return isRunning;
    }
