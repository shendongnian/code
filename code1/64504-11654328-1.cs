    public DateTime filesystemDateTime(string path)
    {
        //create temp file
        string tempFilePath = Path.Combine(path, "lampo.tmp");
        using (File.Create(tempFilePath)) { }
        //read creation time and use it as current source filesystem datetime
        DateTime dt = new FileInfo(tempFilePath).LastWriteTime;
        //delete temp file
        File.Delete(tempFilePath);
        return dt;
    }
