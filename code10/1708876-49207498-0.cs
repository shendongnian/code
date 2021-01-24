    // Abstract base class
    public abstract class BaseMessage
    {
        public string To { get; protected set; }
        public string From { get; protected set; }
        public abstract string MessageType { get; }
        public BaseMessage(string to, string from)
        {
            To = to;
            From = from;
        }
    }
    // Concrete class for every message type.
    public class HearthbeatMessage : BaseMessage
    {
        public override string MessageType
        {
            get
            {
                return "Hearthbeat";
            }
        }
    }
