    private void CallbackMethod(IAsyncResult iresult)
    {
    //logic
    AsyncResult iResult = iresult as AsyncResult;
    MyDelegate del = iResult.AsyncDelegate as MyDelegate;
    IDictionary<string,int> result = del.EndInvoke(iresult);
    }
