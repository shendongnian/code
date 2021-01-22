    public static bool IsFileInUseBadMethod(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return false;
        }
    
        try
        {
            using (StreamReader reader = new StreamReader(File.Open(filePath, FileMode.Open, FileAccess.ReadWrite)))
            {
                return false;
            }
        }
        catch (IOException)
        {
            return true;
        }
    }
