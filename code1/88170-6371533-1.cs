    bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
    {
        try
        {
            using (FileStream fs = File.Create(
                Path.Combine(
                    path, 
                    Path.GetRandomFileName()
                ), 
                1,
                FileOptions.DeleteOnClose)
            )
            { }
            return true;
        }
        catch
        {
            if (throwIfFails)
                throw;
            else
                return false;
        }
    }
