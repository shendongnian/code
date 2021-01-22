    if(Application.Current.Dispatcher.CheckAccess())
    {
        this.progressBar.Value = 50;
    }
    else
    {
        Application.Current.Dispatcher.BeginInvoke(
          DispatcherPriority.Background,
          new Action(() => { 
            this.progressBar.Value = 50;
          }));
    }
