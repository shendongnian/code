    public void SomeActionToBeInvokedOnTheMainThread()
    {
        if (someControl.Dispatcher.CheckAccess())
        {
            // you can modify the control
        }
        else
        {
            someControl.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Normal,
                new Action(SomeActionToBeInvokedOnTheMainThread)
            );
        }
    }
