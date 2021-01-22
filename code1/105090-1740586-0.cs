    public override OnPreviewMouseDown(MouseButtonEventArgs e)
    {
      _mouseClickedButNoFocus = true;
      Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
      {
        if(_mouseClickedButNoFocus)
          Focus();
      });
    }
