    private async void OnEventOccurred(object sender, EventArgs e)
    {
        await Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(SomeLongRunningOperation));
        MessageBox.Show("SomeLongRunningOperation has been executed!");
    }
