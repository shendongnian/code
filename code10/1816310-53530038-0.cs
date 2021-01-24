    string lastText;
    private string GroupListText => ((HTMLDocument)Form.RosterBrowser.Document).getElementById("groupList").innerText;
    public void startTimer()
    {
        lastText = GroupListText;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += dispatcherTimer_Tick;
        dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        dispatcherTimer.Start();
    }
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        var thisText = GroupListText;
        LogTextBlockControl.Text += "DOCUMENT THIS: " + thisText.Length.ToString();
        LogTextBlockControl.Text += "DOCUMENT LAST: " + lastText.Length.ToString();
    }
