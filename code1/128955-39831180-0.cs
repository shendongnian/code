    var enumerator = enumerable.GetEnumerator();
    
    try
    {
        while (enumerator.MoveNext())
        {
            var item = enumerator.Current;
            // do stuff
        }
    }
    finally
    {
        var disposable = enumerator as IDisposable;
        if (disposable != null)
        {
            disposable.Dispose();
        }
    }
