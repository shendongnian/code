    public class Message
    {
        public string content { get; set; }
        public Message(string content)
        {
            this.content = content;
        }
    }
    public class MsgSent:Message
    {
        public MsgSent(string content) : base(content) { }
    }
    public class MsgRecieved : Message
    {
        public MsgRecieved(string content) : base(content) { }
    }
