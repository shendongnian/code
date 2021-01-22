    using System;
    using System.Collections.Generic;
    public abstract class OutboxManagerBase
    {
    private List<string> _OutboxMsgs;
    public DistributeOutboxMessages()
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
    private void RetrieveMessages() 
    {
      //retrieve messages from the database; poplate _OutboxMsgs.
      //This code stays the same in each implementation.
    }
    protected abstract void SendMessagesToVendor();
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
    public class OutBoxImp1 : OutboxManagerBase
    {
        protected override void SendMessagesToVendor()
        {
            throw new NotImplementedException();
        }
    }
