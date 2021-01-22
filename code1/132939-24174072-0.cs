    [SetUp]
    public void SetUp()
    {
        // Replace pop-up assert trace listener with one that simply logs a message.
        Debug.Listeners.Clear();
        Debug.Listeners.Add(new ConsoleTraceListener());
    }
