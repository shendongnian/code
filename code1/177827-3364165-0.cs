    public T DoMethod<T>( Func<T> mainCode, Func<Exception, T> exceptionHandlerCode)
    {
        Tracing.StartOfMethod("Repository");
        try
        {
            return mainCode.Invoke();
        }
        catch (Exception ex)
        {
             ErrorSignal.FromCurrentContext().Raise(ex);
             return exceptionHandlerCode.Invoke(ex);
        }
        finally
        {
            // sometimes something here
            Tracing.EndOfMethod();
        }
    }
