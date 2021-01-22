    private static void OnIsFocusedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var uie = (UIElement)d;
      if ((bool)e.NewValue)
      {
        var action = new Action(() => uie.Dispatcher.BeginInvoke((Action)(() => uie.Focus())));
        Task.Factory.StartNew(action);
      }
    }
