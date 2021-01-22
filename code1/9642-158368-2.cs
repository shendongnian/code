    public static bool HandleException(Exception ex, params Param[] parameters)
    {
       ...
    }
    ...
    if (ExceptionHandler.HandleException(
                        ex, 
                        new Param { Name = "lineNumber", Value=lineNumber },
                        new Param { Name = "text", Value=text },
                        new Param { Name = "context", Value=context}
                        ))
    {
        throw;
    }
    ...
