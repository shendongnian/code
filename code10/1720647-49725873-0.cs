    while(exception != null)
    {
       Console.Error.WriteLine(exception);
       if(exception.InnerException != null)
          exception = exception.InnerException;
    }
