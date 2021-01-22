    public void ProcessMessage(IMessage msg)
    {
        switch(msg.GetMsgType())  // GetMsgType() is defined in IMessage
        {
            case MessageTypes.Order:
                ProcessOrder(msg as OrderMessage);  // Or some other processing of order message
                break;
            case MessageTypes.Trade:
                ProcessTrade(msg as TradeMessage); //  Or some other processing of trade message
            break;
            ...
        }
    }
