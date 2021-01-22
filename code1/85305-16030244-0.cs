    label.Text = "Please Wait...";
    Task<string> task = Task<string>.Factory.StartNew(() =>
    {
        try
        {
            SomewhatLongRunningOperation();
            return "Success!";
        }
        catch (Exception e)
        {
            return "Error: " + e.Message;
        }
    });
    Task UITask = task.ContinueWith((ret) =>
    {
        label.Text = ret.Result;
    }, TaskScheduler.FromCurrentSynchronizationContext());
