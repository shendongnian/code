    IAsyncResult BeginMyFunction(AsyncCallback callback)
    {
        return BeginMyFunction(callback, null);
    }
    IAsyncResult BeginMyFunction(AsyncCallback callback, object context)
    {
        Func<int> del = MyFunction;
        return del.BeginInvoke(callback, context);
    }
    int EndMyFunction(IAsyncResult result)
    {
        Func<int> del = MyFunction;
        return del.EndInvoke(result);
    }
