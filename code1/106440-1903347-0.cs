    private void OnChanged(object source, FileSystemEventArgs e)
    {
        try
        {
            using (var fs = File.OpenWrite(e.FullPath))
            {
            }
            //do your stuff
        }
        catch (Exception)
        {
            //no write access, other app not done
        }
    }
