    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // First, handle the case where an exception was thrown.
        if (e.Error != null)
        {
    	// handle the System.Exception
            MessageBox.Show(e.Error.Message);
        }
        else if (e.Cancelled)
        {
            // now handle the case where the operation was cancelled... 
            lblCase.Content = "The operation was cancelled";
        }
        else
        {
            // Finally, handle the case where the operation succeeded
            lblCase.Content = e.Result.ToString();
        }
    }
