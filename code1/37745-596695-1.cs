    IAsyncResult BeginMyFunction(AsyncCallback callback)
    {
        return BeginMyFunction(callback, null);
    }
    IAsyncResult BeginMyFunction(AsyncCallback callback, object context)
    {
        // Func<int> is just a delegate that matches the method signature,
        // It could be any matching delegate and not necessarily be *generic*
        // This generic solution does not rely on generics ;)
        return new Func<int>(MyFunction).BeginInvoke(callback, context);
    }
    int EndMyFunction(IAsyncResult result)
    {
        return new Func<int>(MyFunction).EndInvoke(result);
    }
