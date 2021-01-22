    delegate void ShowMessageCallback(string message);
    
    private void Form1_Load(object sender, EventArgs e)
    {
        ShowMessageCallback showMessageDelegate = new ShowMessageCallback(ShowMessage);
    }
    private void ShowMessage(string message)
    {
        if (this.InvokeRequired)
            this.Invoke(showMessageDelegate, message);
        else
            labelMessage.Text = message;           
    }
    void Message_OnMessage(object sender, Utilities.Message.MessageEventArgs e)
    {
        ShowMessage(e.Message);
    }
