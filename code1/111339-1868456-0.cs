    private void RenameFile(String oldFilename, String newFilename)
    {
        FileInfo file = new FileInfo(oldFilename);
        if (file.Exists)
        {
            File.Move(oldFilename, newFilename);
        }
    }
