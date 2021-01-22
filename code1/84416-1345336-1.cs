    class ProcessingCompleteEventArgs : EventArgs
    {
        public ProcessingCompleteEventArgs(int itemsProcessed)
        {
            this.ItemsProcessed = itemsProcessed;
        }
    
        public int ItemsProcessed
        {
            get;
            private set;
        }
    }
    
    // ...
    
    // event declaration would look like this:
    public event EventHandler<ProcessingCompleteEventArgs> ProcessingComplete;
