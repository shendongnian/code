    public struct QueueRequest
    {
        public MessageTranslateRequest Request { get; set; }
        public TCPClientService Sender { get; set; }
        public TCPClientService Recipient { get; set; }
    }
