    public virtual bool MoveFiles(string fileName)
    {
        bool retVal = false;
        try
        {
            string sourcePath = "PathSource";
            string destinationPath = "DestPath";
            if (Directory.Exists(sourcePath) && Directory.Exists(destinationPath))
            {
                string finalPath = sourcePath + "\\" + fileName;
                if (Directory.Exists(finalPath))
                {
                    File.Move(finalPath, destinationPath);
                    retVal = true;
                }
                else
                {
                    throw new ArgumentException("Source file does not exists");
                }
            }
        }
        catch (Exception ex)
        {
            LogMessage("Exception Details: " + ex.Message);
            retVal = false;
        }
        return retVal;
    }
