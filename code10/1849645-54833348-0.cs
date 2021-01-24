    public string[] GetFilesImg4() //jpg files
    {
        string tempPath = @"C:\temporario";
        if (!Directory.Exists(tempPath))
        {
            foreach (string filename in listimga.Items)
            {
                if (!filename.Contains("protected"))
                    list4.Add(Path.Combine(tempPath, filename);
            }
        }
        return (string[])list4.ToArray(typeof(string));
    }
