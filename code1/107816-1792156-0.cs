    if(textbox.Dispatcher.CheckAccess())
    {
       // The calling thread owns the dispatcher, and hence the UI element
       textbox.AppendText(...);
    }
    else
    {
       // Invokation required
       textbox.Dispatcher.Invoke(DispatcherPriority.Normal, [delegate goes here]);
    }
