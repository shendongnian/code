    public object Operation(object arg)
    {
        var ar = BeginOperation(arg, null, null);
        return EndOperation(ar);
    }
    public IAsyncResult BeginOperation(object arg, AsyncCallback asyncCallback, object state)
    {
        AsyncResult asyncResult = new AsyncResult(asyncCallback, state);
        // Lauch the asynchronous operation
        return asyncResult;
    }
    private void LaunchOperation(AsyncResult asyncResult)
    {
        // Do something asynchronously and call OnOperationFinished when finished
    }
    private void OnOperationFinished(AsyncResult asyncResult, object result)
    {
        asyncResult.Complete(result);
    }
    public object EndOperation(IAsyncResult asyncResult)
    {
        AsyncResult ar = (AsyncResult)asyncResult;
        return ar.EndInvoke();
    }
