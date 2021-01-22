    uiUpdateTimer = new System.Threading.Timer(new TimerCallback(
                UpdateUI), null, 200, 200);
    private void UpdateUI(object state)
    {
        this.BeginInvoke(new MethodInvoker(UpdateUI));
    }
    private void UpdateUI()
    {
        // modify labels here
    }
