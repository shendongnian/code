    public static void ForceUIToUpdate()
    {
      DispatcherFrame frame = new DispatcherFrame();
      Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Render, new DispatcherOperationCallback(delegate(object parameter)
      {
        frame.Continue = false;
        return null;
      }), null);
      Dispatcher.PushFrame(frame);
    }
