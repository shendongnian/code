    private bool IsFileLocked()
            {
        try
                    {
                        FileStream fs = File.OpenWrite(FilePath);
                        fs.Close();
                        return false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("File locked: " + FileName);
                        return true;
                    }
    }
