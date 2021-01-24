    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InvalidCharacterInFileNameTest()
    {
        string filename = "test>";
        Class1 serviceObj = new Class1();
        serviceObj.MoveFiles(filename);
    }
