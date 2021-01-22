        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            MessageLabel.Text = "Working...";
            RefreshButton_Click.IsEnabled = false;
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                // do work here
                this.Dispatcher.Invoke((Action)delegate()
                   {
                       MessageLabel.Text = "Done.";
                       RefreshButton.IsEnabled = true;
                   });
            });
        }
