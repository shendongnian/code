    ObservableCollection<Message> letsChat = new ObservableCollection<Message>();
    letsChat.Add(new MsgRecieved("Hello world! \nHow are you?"));
    letsChat.Add(new MsgSent("Hi, good to see you!"));
    letsChat.Add(new MsgSent("Hey, are you still there?"));
    letsChat.Add(new MsgSent("Please let me know when you are back."));
    letsChat.Add(new MsgRecieved("Hello world! \nHow are you?"));
    viewChat.DataContext = letsChat;
