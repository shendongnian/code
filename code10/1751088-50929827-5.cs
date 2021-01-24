    [Test]
    public void Test()
    {
        FileEx.EnumerateFiles = (_) => new [] { "file1", "file2" };
        
        // your test here
        // Reset the method:
        FileEx.EnumerateFiles = Directory.EnumerateFiles;
    }
