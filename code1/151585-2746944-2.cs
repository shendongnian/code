    private void RunWorkerCompleted()
    {
        while (_showingMessage)
        {
            Thread.Sleep(500); // or some other interval (in ms)
        }
        this.Close();
    }
    private void ShowSomeMessage()
    {
        _showingMessage = true;
        MessageBox.Show("message");
        _showingMessage = false;
    }
