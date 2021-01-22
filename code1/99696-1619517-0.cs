    interface IMessagingClient
    {
        string MessageToSend { get; set; }
        string MessageBuffer { get; }
        void SendMessage();
    }
