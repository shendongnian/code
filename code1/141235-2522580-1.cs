    private readonly object chartUpdatingLock = new object();
    
    private void UpdateChartTimerElapsed(object sender, ElapsedEventArgs e)
    {
        // Try and get a lock, this will cater for the case where two or more events fire
        // in quick succession.
        if (Monitor.TryEnter(chartUpdatingLock)
        {        
            this.updateChartTimer.Enabled = false;
            try
            {
                // Dequeuing and whatever other work here..
    
                // Invoke the UI thread to update the control
                this.myChartControl.Invoke(new MethodInvoker(delegate
                    {
                        // Do you UI work here
                    })); 
            }
            finally
            {
                this.updateChartTimer.Enabled = true;
                Monitor.Exit(chartUpdatingLock);
            }
        }
    }
