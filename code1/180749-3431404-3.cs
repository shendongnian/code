    public void DoEvents()
    {
        DispatcherFrame frame = new DispatcherFrame();
        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
            new DispatcherOperationCallback(ExitFrames), frame);
        Dispatcher.PushFrame(frame);
    }
    public object ExitFrames(object f)
    {
        ((DispatcherFrame)f).Continue = false;
        return null;
    }
    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 500; i++)
        {
            label.Content = i.ToString();
            DoEvents();
        }
    }
