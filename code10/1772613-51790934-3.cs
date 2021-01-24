    IEnumerable<Message> ConvertMessages()
    {
        foreach (var message in messages)
            if(message is TextMessageData tmd)
                yield return new TextMessage()
                {
                    ImageUrl = tmd.Url,
                    Sender = tmd.Sender,
                    TimeSent = tmd.TimeSent
                }
            else if (message is ImageDataRecord ird)
                yield return new ImageMessage()
                {
                    ImageUrl = ird.Url,
                    Sender = ird.Sender,
                    TimeSent = ird.TimeSent
                }
    }
