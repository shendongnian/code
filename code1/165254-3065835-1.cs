    private void cancelAsyncButton_Click(System.Object sender, 
        System.EventArgs e)
    {   
        // Cancel the asynchronous operation.
        this.backgroundWorker1.CancelAsync();
    }
