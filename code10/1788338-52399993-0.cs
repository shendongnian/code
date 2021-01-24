        try
        {
            fStream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
        }
        catch (IOException)
        {
            //File is being used
            return true;
        }
        finally
        {
            if (fStream != null)
                fStream.Close();
        }
