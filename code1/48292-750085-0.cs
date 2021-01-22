    static ManualResetEvent finishGate;
    static void Main(string[] args)
    {
        finishGate = new ManualResetEvent(false); // initial state unsignaled
        Telnet telCon = new Telnet();
        telCon.OnDataIn += new Telnet.OnDataInHandler(HandleDataIn);
        telCon.Connect(remoteHostStr);
        finishGate.WaitOne(); // waits until the gate is signaled
    }
    public static void HandleDataIn(object sender, TelnetDataInEventArgs e)
    {
        // handle event
        if (processingComplete)
            finishGate.Set(); // signals the gate
    }
