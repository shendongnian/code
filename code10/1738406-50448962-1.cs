    private void Worker_ListenForNewSMS(object sender, DoWorkEventArgs e)
    {
        while (true)
        {
            Thread.Sleep(2000);
            Dispatcher.BeginInvoke(new Action(() =>
            {
                listview1.ItemsSource = new List<string> { "NEWDATA" };
            }));
        }
    }
