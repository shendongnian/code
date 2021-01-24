    private async void Cancel_Clicked(object sender,EventArgs args)
    {
        if (_cts!=null)
        {
           lblStatus.Text = "Cancelling";
           //Signal a cancellation
            _cts.Cancel();
           //Asynchronously wait for all tasks to finish
            await Task.WhenAll(_tasks);
            _cts=null;           
           lblStatus.Text = "Cancelled";
        }
        //Disable the button
        Cancel.Enabled=false;
    }
