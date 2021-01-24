    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //...
        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        {
            //this code gets executed on the UI thread
            yourCollection.Add(...);
        }));
    }
