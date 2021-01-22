    try
    {
    ...
    }
    catch (System.Exception ex)
    {
       if (ex is ExceptionTypeA or ExceptionTypeB or ExceptionTypeC)
       {
           ... same code ...
       }
       else
           throw;
    }
