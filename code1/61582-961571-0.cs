        FileStream FS = null;
        try
        {
            FS = new FileStream(this.InFile, FileMode.Open, FileAccess.Read);
            return "";
        }
        catch (FileNotFoundException ex)
        {
            return ex.Message;
        }
        finally
        {
            if (FS != null) {
                FS.Close();
                FS.Dispose();
            }
        }
