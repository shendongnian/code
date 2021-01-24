    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        //Keep it running for 5 minutes
        CancellationTokenSource cts = new CancellationTokenSource(new TimeSpan(hours: 0, minutes: 5, seconds: 0));
        //Keep it running until user closes the app
        //CancellationTokenSource cts = new CancellationTokenSource();
        //Go to a different thread
        Task.Run(() =>
        {
            //Some dummy variable
            long millisecondsSlept = 0;
            //Make sure cancellation not requested
            while (!cts.Token.IsCancellationRequested)
            {
                //Some heavy operation here
                Thread.Sleep(500);
                millisecondsSlept += 500;
                //Update UI with the results of the heavy operation
                Application.Current.Dispatcher.Invoke(() => txtCpu.Text = millisecondsSlept.ToString());
            }
        }, cts.Token);
    }
