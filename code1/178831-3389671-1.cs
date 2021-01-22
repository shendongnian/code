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
        catch (Exception ex) {
            LogErrorMessageInDb(ex);
        }
     }
    
        private void RetrieveMessages() 
        {
          //retrieve messages from the database; poplate _OutboxMsgs.
          //This code stays the same in each implementation.
        }
    
        protected abstract void SendMessagesToVendor();   // <== THIS CODE CHANGES EACH IMPLEMENTATION
        
    
        private void MarkMessagesAsProcessed()
        {
          //If SendMessageToVendor() worked, run this method to update this db.
          //This code stays the same in each implementation.
        }
    
        private void LogErrorMessageInDb(Exception ex)
        {
          //This code writes an error message to the database
          //This code stays the same in each implementation.
        }
    }
