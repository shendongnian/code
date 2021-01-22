    var disposableObject = new object_that_implements_IDisposable()
    try
    {
        ...
    }
    finally
    {
        if(disposableObject != null)
        {
            ((IDisposable)your_object).Dispose();
        }
    }
