    private bool _handleClose = true;
    protected override async void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        if (_handleClose)
        {
            e.Cancel = true;
            await Task.Delay(5000);// a very long procedure!
            _handleClose = false;
            Close();
        }
    }
