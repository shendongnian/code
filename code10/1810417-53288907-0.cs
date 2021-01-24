    private void moveDirectory(string sourcePath ,string targetPath)
    {
        if (!System.IO.Directory.Exists(targetPath))
        {
            System.IO.Directory.CreateDirectory(targetPath);
        }
        String[] files = Directory.GetFiles(sourcePath);
        String[] directories = Directory.GetDirectories(sourcePath);
        foreach (string f in files)
        {
            System.IO.File.Copy(f, Path.Combine(targetPath,Path.GetFileName(f)), true);     
        }
        foreach(string d in directories)
        {
            // recursive call
            moveDirectory(Path.Combine(sourcePath, Path.GetFileName(d)), Path.Combine(targetPath, Path.GetFileName(d)));
        }
    }
