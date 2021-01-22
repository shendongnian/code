    private static void WaitUntilAsyncStreamReachesEndOfFile(Process process, string field)
    {
        FieldInfo asyncStreamReaderField = typeof(Process).GetField(field, BindingFlags.NonPublic | BindingFlags.Instance);
        object asyncStreamReader = asyncStreamReaderField.GetValue(process);
    
        Type asyncStreamReaderType = asyncStreamReader.GetType();
    
        MethodInfo waitUtilEofMethod = asyncStreamReaderType.GetMethod(@"WaitUtilEOF", BindingFlags.NonPublic | BindingFlags.Instance);
    
        object[] empty = new object[] { };
    
        waitUtilEofMethod.Invoke(asyncStreamReader, empty);
    }
