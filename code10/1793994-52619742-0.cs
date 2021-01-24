        try
        {
            MessageBoxResult result = await ShowMessageBoxAsync(e.Message);
            if (result == MessageBoxResult.OK)
                _log.InfoFormat("acknowledged");
            else
                _log.InfoFormat("no acknowledge");
        }
        public async Task<MessageBoxResult> ShowMessageBoxAsync(string message)
        {
            await Task.Run(() =>
            {
              return Application.Current.Dispatcher.Invoke(() => MessageBox.Show(Application.Current.MainWindow, message, "Message", MessageBoxButton.OK, MessageBoxImage.Information));
            });
        }
