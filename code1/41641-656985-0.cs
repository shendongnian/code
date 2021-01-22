    class EmailSender
    {
      object SimultaneousEmailsLock;
      int SimultaneousEmails;
      public string[] Recipients;
      
      void SendAll()
      {
        foreach(string Recipient in Recipients)
        {
          while (SimultaneousEmails>10) Thread.Sleep(10);
          SendAnEmail(Recipient);
        }
      }
      
      void SendAnEmail(string Recipient)
      {
        lock(SimultaneousEmailsLock)
        {
          SimultaneousEmails++;
        }
        
        ... send it ...
      }
      
      void FinishedEmailCallback()
      {
        lock(SimultaneousEmailsLock)
        {
          SimultaneousEmails--;
        }
        
        ... etc ...
      }
    }
