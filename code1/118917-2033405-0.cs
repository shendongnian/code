    private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	if(e.Error != null)
    	{
    		MessageBox.Show("Error in async operation: " + ex.Message);
    	}
    	else
    	{
    		//process results
    	}
    }
