    var receivedMessageModel = ConversationCollection[0] as ReceivedMessageModel;
    if (receivedMessageModel != null)
    {
        //the first item is a ReceivedMessageModel
    }
    else
    {
        var sendMessageModel = ConversationCollection[0] as SendMessageModel;
        // the first item is A SendMessageModel
    }
