    _VisibilityWindow = false;
    OnPropertyChanged("VisibilityWindow");
    System.Windows.Application.Current?.Dispatcher?.Invoke(() =>
      {
        Screenshot.captureAll();
        _VisibilityWindow = true;
        OnPropertyChanged("VisibilityWindow");
      }, DispatcherPriority.ApplicationIdle);
    
