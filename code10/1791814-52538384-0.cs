    private void OnEventOccurred(object sender, EventArgs e)
    {
        Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(SomeLongRunningOperation));
        MessageBox.Show("SomeLongRunningOperation will be executed eventually!");
    }
