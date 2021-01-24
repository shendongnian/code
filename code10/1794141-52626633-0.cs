    public void SomeMethodThatsCalled()
    {
        // I'm presuming there's a lot of other code here, and that the IFileProvider
        // is actually dependency injected somewhere, somehow, but it's self-contained
        // here for completeness
        IFileProvider physicalFileProvider = new PhysicalFileProvider(@"D:\DeleteMyContentsPlease\");
        DeleteFiles(physicalFileProvider);
    }
    private void DeleteFiles(IFileProvider physicalFileProvider)
    {
        if (physicalFileProvider is PhysicalFileProvider)
        {
            var directory = physicalFileProvider.GetDirectoryContents(string.Empty);
            foreach (var file in directory)
            {
                if (!file.IsDirectory)
                {
                    var fileInfo = new System.IO.FileInfo(file.PhysicalPath);
                    fileInfo.Delete();
                       
                }
            }
        }
    }
