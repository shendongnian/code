    public string GetSafeFilename(string filename)
    {
    
        return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
    
    }
