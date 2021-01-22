    void Process()
    {
        // ...
    
        // processing is done, get ready to fire the event
        EventHandler processingComplete = this.ProcessingComplete;
        
        // an event with no subscribers is null, so always check!
        if (processingComplete != null)
        {
            processingComplete(this, EventArgs.Empty);
        }
    }
