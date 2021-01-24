    public void Test()
    {
        var fakeReader = new FakeFileReader();
        var path = "pathToSomeFile"
        var data = new[] { "Line 1", "Line 2", Line 3" };
        fakeReader.Files.Add(path, data)
        ProcessDataFromFile(path, fakeReader);
        // Assert
    }
