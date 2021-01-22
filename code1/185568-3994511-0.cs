    private void Client_SubmitCompleted(object sender, SubmitCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            //...
        }
        else if (e.Error != null)
        {
            // the service operation threw an exception
            throw e.Error;
        }
        else
        {
            //...
        }
