    public static void InvokeIfNecessary(UIElement element, MethodInvoker action)
    {
        if (element.Dispatcher.Thread != Thread.CurrentThread)
        {
            element.Dispatcher.Invoke(DispatcherPriority.Normal, action);
        }
        else
        {
            action();
        }
    }
