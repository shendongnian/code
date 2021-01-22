    public static void AsyncInvoke<T>(this Action<T> action, T param)
    {
        action.BeginInvoke(param, asyncResult => 
        {
            Action<T> a = (Action<T>)asyncResult.AsyncState;
            a.EndInvoke(asyncResult);
        }, action);
    }
