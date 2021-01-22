    try
    {
       // throw
    }
    catch (Exception ex)
    {
       if (ex is ArgumentException || ex is NullReferenceException || ex is FooException)
       {
          // Handle
       }
       else
       {
          throw
       }
    }
