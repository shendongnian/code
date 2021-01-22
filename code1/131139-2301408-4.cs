    Action<string> setStatus= target.AppendText;
    void OnSomeEvent (object sender, EventArgs e)
    { 
        IAsyncRes iares = setStatus.BeginInvoke("status message", null, null); 
        setStatus.EndInvoke(iares);
    }
    public void SetStatus(string msg)
    { lblStatus.Text = msg; }
