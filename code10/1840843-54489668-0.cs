        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Window.GetWindow(this).IsEnabled = false;
                    });
                    Thread.Sleep(5000);
                }
                finally
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Window.GetWindow(this).IsEnabled = true;
                    });
                }
            });
        }
