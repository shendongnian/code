    void ScrollViewer_KeyDown(object sender, KeyEventArgs e)
    {
      if(e.Handled) return;
      var temporaryEventArgs =
        new KeyEventArgs(e.KeyboardDevice, e.InputSource, e.Timestamp, e.Key)
        {
          RoutedEvent = e.RoutedEvent
        };
      // This line avoids it from resulting in a stackoverflowexception
      if (sender is ScrollViewer) return;
      ((ScrollViewer)sender).RaiseEvent(temporaryEventArgs);
      e.Handled = temporaryEventArgs.Handled;
    }
