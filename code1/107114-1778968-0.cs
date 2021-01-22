        private void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Message.Text = "working...";
            Button_Refresh.IsEnabled = false;
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                Thread.Sleep(2000);
                Message.Dispatcher.Invoke((Action)delegate()
                   {
                       Message.Text = "Button is ready to click again.";
                       Button_Refresh.IsEnabled = true;
                   });
            });
        }
