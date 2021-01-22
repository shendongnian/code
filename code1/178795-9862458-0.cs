     private void button1_Click(object sender, RoutedEventArgs e)
    {
        ThreadPool.QueueUserWorkItem(o =>
        {
            int result = 0;
            for (int i = 0; i < 9999999; i++)
            {
                result++;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.label1.Content = result;
                }));
                Thread.Sleep(1);
            }
        });
    }
