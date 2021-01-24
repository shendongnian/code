    private void HandleOutputData(object sender, DataReceivedEventArgs e)
    {
        // The new data is contained in e.Data
        MyProgressViewer.Update(e.Data);
        this.myTextBox.Text += e.Data;
    }
    private void HandleErrorData(object sender, DataReceivedEventArgs e)
    {
        // The new data is contained in e.Data
        MyProgressViewer.Update(e.Data);
        this.myTextBox.Text += e.Data;
        
        // Additional error handling here.
    }
