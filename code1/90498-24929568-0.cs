    private static Tuple<string, string> GetFullExceptionMessageAndStackTrace(Exception exception)
    {
        if (exception.InnerException == null)
        {
            if (exception.GetType() != typeof(ArgumentException))
            {
                return new Tuple<string, string>(exception.Message, exception.StackTrace);
            }
            string argumentName = ((ArgumentException)exception).ParamName;
            return new Tuple<string, string>(String.Format("{0} With null argument named '{1}'.", exception.Message, argumentName ), exception.StackTrace);
        }
        Tuple<string, string> innerExceptionInfo = GetFullExceptionMessageAndStackTrace(exception.InnerException);
        return new Tuple<string, string>(
        String.Format("{0}{1}{2}", innerExceptionInfo.Item1, Environment.NewLine, exception.Message),
        String.Format("{0}{1}{2}", innerExceptionInfo.Item2, Environment.NewLine, exception.StackTrace));
    }
    [Fact]
    public void RecursiveExtractingOfExceptionInformationOk()
    {
        // Arrange
        Exception executionException = null;
        var iExLevelTwo = new NullReferenceException("The test parameter is null");
        var iExLevelOne = new ArgumentException("Some test meesage", "myStringParamName", iExLevelTwo);
        var ex = new Exception("Some higher level message",iExLevelOne);
    
        // Act 
        var exMsgAndStackTrace = new Tuple<string, string>("none","none");
        try
        {
            exMsgAndStackTrace = GetFullExceptionMessageAndStackTrace(ex);
        }
        catch (Exception exception)
        {
            executionException = exception;
        }
                
        // Assert
        Assert.Null(executionException);
    
        Assert.True(exMsgAndStackTrace.Item1.Contains("The test parameter is null"));
        Assert.True(exMsgAndStackTrace.Item1.Contains("Some test meesage"));
        Assert.True(exMsgAndStackTrace.Item1.Contains("Some higher level message"));
        Assert.True(exMsgAndStackTrace.Item1.Contains("myStringParamName"));
    
        Assert.True(!string.IsNullOrEmpty(exMsgAndStackTrace.Item2));
        Console.WriteLine(exMsgAndStackTrace.Item1);
        Console.WriteLine(exMsgAndStackTrace.Item2);
    }
