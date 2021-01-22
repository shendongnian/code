    private void GetFiles(DirectoryInfo dir, ref List<FileInfo> files)
    {
        try
        {
            files.AddRange(dir.GetFiles());
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (var d in dirs)
            {
                GetFiles(d, ref files);
            }
        }
        catch (Exception e)
        {
           
        }
    }
