    private void Browser_LoadingStateChanged(object sender, CefSharp.LoadingStateChangedEventArgs e) {
       if (!e.IsLoading) {
          // set the cursor back to arrow
          Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
             new Action(() => Mouse.OverrideCursor = Cursors.Arrow));
       }
    }
