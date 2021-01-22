    public DateTime remoteDateTime(string path)
    {
        string tempFilePath = Path.Combine(path, "flash.tmp");
        var tempFile = File.Create(tempFilePath);
        tempFile.Close();
        DateTime dt = new FileInfo(tempFilePath).LastWriteTime;
        File.Delete(tempFilePath);
        return dt;
    }
