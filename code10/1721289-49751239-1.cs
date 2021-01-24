    [TestMethod]
    [ExpectedException(typeof(IOException))]
    public void RecordAnalyser_Should_FailInFirstAttempt_When_FileRead() {
        //Arrange
        var fileMock = Substitute.For<IFile>();
        fileMock.ReadLines(Arg.Any<string>()).Throws(new IOException());
        //Act
        var recordAnalyser = new RecordAnalyser(fileMock, logger); //--> throws exception.
    }
