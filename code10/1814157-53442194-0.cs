    var length = 1000;
    
    Task.Run(() =>
    {
        for (int i = 0; i <= length; i++)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => { 
                lblMsg.Content = "Test" + i;
            }), DispatcherPriority.Render);
            Thread.Sleep(100);
        }
    });
