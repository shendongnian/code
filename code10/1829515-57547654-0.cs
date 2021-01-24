    public void SendKeys(string message)
    {
        foreach (char c in message)
        {
            _browser.Window.WindowUtils.SendNativeKeyEvent(0, 0, 0, c.ToString(), c.ToString());
            Task.Delay(10).Wait();
        }
    }
