    Messenger.Default.Register<DialogMessage>(this, ProcessDialogMessage);
    ...
    private void ProcessDialogMessage(DialogMessage message)
    {
         // Instantiate new view depending on the message details
    }
