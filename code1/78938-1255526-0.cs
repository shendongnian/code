    private void BackgroundWorker_RunWorkerCompleted(object sender, 
                               System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(
                new Action<object, RunWorkerCompletedEventArgs>(
                                   BackgroundWorker_RunWorkerCompleted), sender, e);
        }
        else
        {
            // update the message list, and then call SetMessages()
            SetMessages();
        }
    }
