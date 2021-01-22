    // return type changed to void to match target.
    internal delegate void delegateMethod(object args);
    // obj parameter added
    public static void PublishAsyncMethod(object obj, MethodInfo method, MethodInfo callback)
    {
        delegateMethod dMethod = (delegateMethod)Delegate.CreateDelegate
            (typeof(delegateMethod), obj, method, true);
        
        AsyncCallback callBack = (AsyncCallback)Delegate.CreateDelegate
             (typeof(AsyncCallback), obj, callback);
       
    }
    DelegateHandler.PublishAsyncMethod(
        this, // pass this pointer needed to bind instance methods to delegates.
        this.GetType().GetMethod("InitializeComponents"),
        this.GetType().GetMethod("Components_Initialized"));
