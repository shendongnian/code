    public Action f;
    public YourClassName()
    {
        f = () => 
        {
            Dispatcher.Invoke(() => {what I must do in the UI thread });
        }
    }
