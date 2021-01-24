    public void ConfigureFile(string loadDirectory)
    {
        using (ZipFile zip = ZipFile.Read(loadDirectory))
        {
            zip.AddEntry(@"Folder1\Test.txt", new byte[] { 1, 2, 3 });
            zip.Save();
        }
    }
