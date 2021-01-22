    public event EventHandler MessageReceived;
    private void UnsolicitedMessageReceived(...)
    {
      if (MessageReceived != null)
      {
       // this will invoke on UI thread
       Parent.Invoke(MessageReceived, this, EventArgs.Empty);
      }
    }
    
