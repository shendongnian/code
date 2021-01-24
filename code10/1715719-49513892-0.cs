    {
        SqlConnection sqlConnection = new SqlConnection(“................”);
        sqlConnection.Open();
        sqlConnection.InfoMessage += new SqlInfoMessageEventHandler(ProgressStatus);
    
        // Execute your long running query here
    }
    private void ProgressStatus(object sender, SqlInfoMessageEventArgs e) 
    {
       if (e.Errors.Count > 0)
       {
           string message = e.Errors[0].Message;
           int state = e.Errors[0].State;
           // Set status of the progress bar
           // progressBar1.Value = state;
       }
    }
