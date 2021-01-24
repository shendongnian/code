    bgworker.RunWorkerCompleted += JobCompleted;
    
    private void JobCompleted(
        object sender, RunWorkerCompletedEventArgs e)
    {
        // First, handle the case where an exception was thrown.
        if (e.Error != null)
        {
            MessageBox.Show(e.Error.Message);
        }
        else if (e.Cancelled)
        {
            MessageBox.Show("Job cancelled");
        }
        else
        {
            do_next_stuff();
        }
    
    }
