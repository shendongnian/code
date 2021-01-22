    // Creating the DispatcherTimer
    var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
    dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
    dispatcherTimer.Start();
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        if (this.ProcessingEvents)
            return;
        this.ProcessingEvents = true;
        var messagesLeft = true;
        while (messagesLeft)
        {
            TRxMsg receivedMessage;
            ReadMessage(devHandle, out receivedMessage);
            // Process message
            // Set messagesLeft to false if no messages left
        }
        this.ProcessingEvents = false;
    }
