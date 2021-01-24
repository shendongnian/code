    private void DTP_SessionDate_Validating(object sender, 
 				System.ComponentModel.CancelEventArgs e)
    {
        if(DTP_SessionDate.Value < DateTime.Now)
        {
            e.Cancel = true;
            DTP_SessionDate.Value=DateTime.Now;
            // Set the ErrorProvider error with the text to display. 
            this.errorProvider1.SetError(DTP_SessionDate, "you cannot choose time less than the current time");
         }
    }
    private void DTP_SessionDate_Validated(object sender, System.EventArgs e)
    {
       // If all conditions have been met, clear the ErrorProvider of errors.
       errorProvider1.SetError(DTP_SessionDate, "");
    }
