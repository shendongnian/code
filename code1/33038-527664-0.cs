    [TestMethod]
    public void Meh()
    {
        var mockFileSystem = MockRepository.GenerateMock<IFileSystemService>();
        mockFileSystem.Stub(fs => fs.CreateFileStream(null, FileMode.Append, FileAccess.Write, FileShare.None))
            .IgnoreArguments()
            .Return(null) 
            //*****The return value is replaced in the next line!
            .WhenCalled(invocation => invocation.ReturnValue = new MemoryStream());
    
        var result1 = mockFileSystem.CreateFileStream(null, FileMode.Append, FileAccess.Write, FileShare.None);
        var result2 = mockFileSystem.CreateFileStream(null, FileMode.Append, FileAccess.Write, FileShare.None);
        Assert.AreNotSame(result1, result2);
    }
