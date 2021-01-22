    // C#
    public void ThreadProc()
    {
        // Use the UpdateCount function to update the display
        EventHandler threadDelegate =
            new EventHandler(this.UpdateCounter);
    
        // Run until the application tries to shutdown
        do
        {
            // Call the counter updating function
        this.Invoke(threadDelegate);
        Thread.Sleep(200);
        }
        while(!this.closeRequested);
    
        // Close the thread
        this.Invoke(new EventHandler(this.CloseMe)); // <-- There you go
    }
