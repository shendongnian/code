    class EventChain
    {    
        public event EventHandler Phase1Completed;
        public event EventHandler Phase2Completed;
        public event EventHandler Phase3Completed;
    
        protected void OnPhase1Complete()
        {
            if (Phase1Completed != null)
            {
                Phase1Completed(this, EventArgs.Empty);
            }
        }
    
        public void Process()
        {
            // Do Phase 1
            ...
            OnPhase1Complete();
    
            // Do Phase 2
            ...
            OnPhase2Complete();    
        }
    }
