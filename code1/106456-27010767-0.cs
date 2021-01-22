    FileReadTime = DateTime.Now;
    private void File_Changed(object sender, FileSystemEventArgs e)
    {            
        var lastWriteTime = File.GetLastWriteTime(e.FullPath);
        if (lastWriteTime.Subtract(FileReadTime).Ticks > 0)
        {
            // code
            FileReadTime = DateTime.Now;
        }
    }
