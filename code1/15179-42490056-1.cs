    try
    {
        this._log.Verify(x => x.LogMessage(Logger.WillisLogLevel.Info, Logger.WillisLogger.Usage, "Created the Student with name as"), "Failure");
    }
    Catch 
    {
        Assert.IsFalse(ex is Moq.MockException);
    }
