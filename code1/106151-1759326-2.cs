    List<Type> exceptionsToHandle = new List<Type>{ typeof(ArgumentException), typeof(NullReferenceException), typeof(FooException) };
    try
    {
       // throw
    }
    catch (Exception ex)
    {
       if (exceptionsToHandle.Contains(ex.GetType()))
       {
          // Handle
       }
       else
       {
          throw
       }
    }
