            Task.Run(() =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show(Application.Current.MainWindow, "T", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }), null);
            });
