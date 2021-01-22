    private string LocateEXE(String filename)
    {
        String path = Environment.GetEnvironmentVariable("path");
        String[] folders = path.Split(';');
        foreach (String folder in folders)
        {
            if (File.Exists(folder + filename))
            {
                return folder;
            } 
            else if (File.Exists(folder + filename)) 
            {
                return folder + "\\";
            }
        }
    }
