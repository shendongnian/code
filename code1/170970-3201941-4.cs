    public event EventHandler<MessageBoxEventArgs> Message_Event;
    ...
            if (this.Message_Event!= null)
            {
                this.Message_Event(this, new MessageBoxEventArgs(message));
            }
