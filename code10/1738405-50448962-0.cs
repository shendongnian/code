    private void Worker_ListenForNewSMS(object sender, DoWorkEventArgs e)
    {
        while (true)
        {
            Thread.Sleep(2000);
            Dispatcher.BeginInvoke(new Action(() =>
            {
                mNames.Add("NEWDATA");
            }));
        }
    }
