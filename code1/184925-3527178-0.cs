    DateTime mayContinue = DateTime.MinValue;
    bool blockingUi = false;
    private void Timer_Elapsed(object source, ElapsedEventArgs e)
    {
        if( blockingUi )
        {
            if( DateTime.Now < mayContinue )
            {
                // Notify time remaining
                // Update the UI with a BeginInvoke
            }
            else
            {
                blockingUi = false;
                // Notify ready
                // Update the UI with a BeginInvoke                
            }
        }
    }
    private void BlockUi()
    {
        mayContinue = DateTime.Now.AddSeconds(30);
        blockingUi = true;
    }
