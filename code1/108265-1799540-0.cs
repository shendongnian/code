       void backgroundWorker1_RunWorkerCompleted(object sender, 
            RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                label1.Text = e.Error.Message;
            }
            else if (e.Cancelled)
            {
                label1.Text = "Canceled";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                label1.Text = e.Result.ToString();
            }
            // update UI for Thread completed
        }
  
