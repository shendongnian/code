    void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var window = e.Source as Window;
            System.Threading.Thread.Sleep(100);
            window.Dispatcher.Invoke(
            new Action(() =>
            {
                window.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            }));
        }
