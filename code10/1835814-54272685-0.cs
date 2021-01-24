    public delegate void updateNetworkButtonDelegate(string message);
    public void updateNetworkButton(string message)
    {
        if (!test_btn.Dispatcher.CheckAccess())
        {
            test_btn.Dispatcher.Invoke(new updateNetworkButtonDelegate(updateNetworkButton), message);
        }
        else
        {
           test_btn.Content = message;
        }
    }
