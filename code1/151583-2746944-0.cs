    private void RunWorkerCompleted()
    {
        lock (_locker)
        {
            this.Close();
        }
    }
    private void ShowSomeMessage()
    {
        lock (_locker)
        {
            MessageBox.Show("message");
        }
    }
