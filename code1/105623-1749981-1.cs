    private struct XmlMessage
    {
        private readonly string message;
        private readonly DateTime timeRead;
        public string Message { get { return message; } }
        public DateTime TimeRead { get { return timeRead; } }
        public XmlMessage(string message, DateTime timeRead)
        {
            this.message = message;
            this.timeRead = timeRead;
        }
    }
