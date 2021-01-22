    public void CopyAll(DirectoryInfo source, DirectoryInfo target)
    {
        try
        {
            //check if the target directory exists
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }
            //copy all the files into the new directory
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }
            //copy all the sub directories using recursion
            foreach (DirectoryInfo diSourceDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetDir = target.CreateSubdirectory(diSourceDir.Name);
                CopyAll(diSourceDir, nextTargetDir);
            }
            //success here
        }
        catch (IOException ie)
        {
            //handle it here
        }
    }
