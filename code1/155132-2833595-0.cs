    MyDisposableObject Gimme() 
    {
        MyDisposableObject disposableResult = null;
        try
        {
            MyDisposableObject disposableResult = ...
            // ... Code to prepare disposableResult
            return disposableResult;
        }
        catch(Exception)
        {
            if (disposableResult != null) disposableResult.Dispose();
            throw;
        }
    }
