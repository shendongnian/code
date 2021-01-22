    var thread = new Thread(() =>
    {
      while(!Stop)
      {
        var nextCheck = DateTime.Now.AddSeconds(1);
        CheckWebSite();
        Application.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
        {
          UpdateViewModelWithNewData();
        }));
        int millis = (int)(nextCheck - DateTime.Now).TotalMilliseconds();
        if(millis>0)
          Thread.Sleep(millis);
      }
    });
    thread.IsBackground = true;
    thread.Start();
