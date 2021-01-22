    public abstract class OutboxManager 
    {
        private List<OutboxMsg> _OutboxMsgs;
    
        public void DistributeOutboxMessages()
        {
            try {
                RetrieveMessages();
                SendMessagesToVendor();
                MarkMessagesAsProcessed();
            }
            catch Exception ex {
                LogErrorMessageInDb(ex);
            }
        }
    
        protected void RetrieveMessages() 
        {
          //retrieve messages from the database; poplate _OutboxMsgs.
          //This code stays the same in each implementation.
        }
    
        protected abstract void SendMessagesToVendor()   // <== THIS CODE CHANGES EACH IMPLEMENTATION
        {
          //vendor-specific code goes here.
          //This code is specific to each implementation.
        }
    
        protected void MarkMessagesAsProcessed()
        {
          //If SendMessageToVendor() worked, run this method to update this db.
          //This code stays the same in each implementation.
        }
    
        protected void LogErrorMessageInDb(Exception ex)
        {
          //This code writes an error message to the database
          //This code stays the same in each implementation.
        }
    }
