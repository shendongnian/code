    private void Write(string path, string txt)
    {
        var dir = Path.GetDirectoryName(path);
        try
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            File.WriteAllText(path, txt);
        }
        catch (Exception ex)
        {
            //Log error;
        }
    }
