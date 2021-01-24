    void OnDataReceived(object sender, DataEventArgs e)
    {
        // here we're in the context of the working thread
        // this call will return immediately giving control back to the working thread
        Dispatcher.BeginInvoke(
            DispatcherPriority.Normal,
            (Action)delegate
            {
                // here we are in the context of the UI thread
            });
    }
