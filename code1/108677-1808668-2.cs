    public static IAsyncResult BeginInvoke(this Control control, Delegate del, object[] args, AsyncCallback callback, object state)
    {
        CustomAsyncResult asyncResult = new CustomAsyncResult(callback, state);
        control.BeginInvoke(delegate
        {
            del.DynamicInvoke(args);
            asyncResult.Complete();
        }, args);
    
        return asyncResult;
    }
    
    public static void EndInvoke(this Control control, IAsyncResult asyncResult)
    {
        asyncResult.EndInvoke();
    }
