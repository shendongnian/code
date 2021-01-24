    public static void InvokeAsync<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs args)
    {
        void Callback(IAsyncResult ar)
        {
            var method = (EventHandler<TEventArgs>)ar.AsyncState;
            try
            {
                method.EndInvoke(ar);
            }
            catch (Exception e)
            {
                HandleError(e, method);
            }
        }
        foreach (EventHandler<TEventArgs> handler in eventHandler.GetInvocationList())
            handler.BeginInvoke(sender, args, Callback, handler);
    }
