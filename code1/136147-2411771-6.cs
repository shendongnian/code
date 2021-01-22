    private void App_FormClosing(object sender, FormClosingEventArgs e)     
    {
        // [politely] request termination
        worker.CancelAsync();
        // [politely] wait until background task terminates
        TimeSpan gracePeriod = TimeSpan.FromMilliseconds(100);
        bool isStoppedGracefully = isStopped.WaitOne (gracePeriod);
        if (!isStoppedGracefully)
        {
            // KILL! KILL! KILL!
        }
    }
