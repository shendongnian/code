    public Mock<IFile> GetNewFile(string name)
    {                
        Mock<IFile> file = new Mock<IFile>();
        file.CallBase = true;
        file.Setup(f => f.Name).Returns(name);
        file.Setup(f => f.Path).Returns(@"C:\Folder\" + name);
        file.Setup(f => f.AppendName()).Callback(() => file.Setup(f => f.Name).Returns(() => 
        {
            var localFile = new LocalFile();
            localFile.AppendName();
            return localFile.Name;
            // or just return "AppendedDocument"
        }));   
        return file;
    } 
