    Messenger.Default.Register<string>(this, MessageHandler);
    
    ...
    
    Messenger.Default.Unregister<string>(this, MessageHandler);
