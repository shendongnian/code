    private static Boolean FileInUse(FileInfo file)
            {
                    Boolean inUse = false;
                    try
                    {
                            using (file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {}
                    }
                    catch (Exception exception)
                    {
                            inUse = true;
                    }
    
                    return inUse;
            }
