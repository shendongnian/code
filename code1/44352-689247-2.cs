    public bool Is64bitOS
    {
        get
        {
            return Environment.GetEnvironmentVariable("ProgramFiles(x86)")
                   != null;
        }
    }
    
    public string ProgramFilesX86
    {
        get
        {
            string programFiles =
                Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            if (programFiles == null)
            {
                programFiles = Environment.GetEnvironmentVariable(
                               "ProgramFiles");
            }
    
            return programFiles;
        }
    }
