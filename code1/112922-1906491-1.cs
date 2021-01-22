    private void CallbackMethod(IAsyncResult ar)
    {
        var result = (AsyncResult)ar;
        var caller = (AsyncMethodCaller)result.AsyncDelegate;
        var vm = ar.AsyncState as MyViewModel;
        int returnValue = caller.EndInvoke(ar);
        vm.Result = returnValue; 
    }
