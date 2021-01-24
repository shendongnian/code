    private void Cefbrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    myspin.Visibility = Visibility.Collapsed;
                });
            }
        }
