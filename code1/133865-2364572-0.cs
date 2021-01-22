    var thread = new Thread(() =>
    {
      while(!Stop)
      {
        CheckWebSite();
        Application.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
        {
          UpdateViewModelWithNewData();
        }));
        Thread.Sleep(1000);
      }
    });
    thread.IsBackground = true;
    thread.Start();
