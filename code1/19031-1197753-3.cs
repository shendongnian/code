    public delegate void SaveControlDelegate();
     
    public void InvokeSave(SaveControlDelegate saveControlDelegate)
    {        
        // I've changed the code from our code. 
        // You'll have to make up your own logic.
        // this just gives an idea of common handling.
        retryButton.Visible = false;
        try
        {
            saveControlDelegate.Invoke();
        }
        catch (SqlTimeoutException ex)
        {
            // perform other logic here.
            statusLabel.Text = "The server took too long to respond.";
            retryButton.Visible = true;
            LogSqlTimeoutOnSave(ex);
        }
        // catch other exceptions as necessary. i.e.
        // detect deadlocks
        catch (Exception ex)
        {
            statusLabel.Text = "An unknown Error occurred";
            LogGenericExceptionOnSave(ex);
        }
        SetSavedStatus();
    }
