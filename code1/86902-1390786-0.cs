        private void ProcessProcessCompleted(object sender, object e)
        {
            this.syncContext.Post(new SendOrPostCallback(delegate(object state)
                                                        {
                                                            // Update the user control, etc.
                                                        })
                                  , null);            
        } 
