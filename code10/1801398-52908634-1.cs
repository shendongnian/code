    public void ShouldCallLogWarning()
    {
        var loggerMock = new Mock<ILogger>();
        loggerMock.Setup(_ => _.LogWarning(It.IsAny<string>(), It.IsAny<object>(), null);        
        
        var myClass = new MyClass(loggerMock.Object);
         
        //
        myClass.LogInit(Guid.NewGuid(), "folderPath", null)
        
        //
        _loggerMock.Verify(_ => _.LogWarning(It.IsAny<string>(), It.IsAny<string>(), null), Times.Once());
    }
