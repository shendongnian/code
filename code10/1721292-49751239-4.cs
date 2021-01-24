    [TestMethod]
    public void RecordAnalyser_Should_LogWarning_When_FileReadFailedInFirstAttempt() {
        //Arrange
        var fileMock = Substitute.For<IFile>();
        fileMock.ReadLines(Arg.Any<string>()).Throws(new IOException());
        IOException error = null;
        
        //Act
        try {
            var recordAnalyser = new RecordAnalyser(fileMock, logger); //--> throws exception.
        } catch(IOException ex) {
            error = ex; //catch and hold error for later
        }
        
        //Assert
        
        if(error == null)
            Assert.Failed("exception expected"); // error was not thrown.
        
        logger.Received(1).Warn(Arg.Any<string>(), Arg.Any<Exception>());
    }    
