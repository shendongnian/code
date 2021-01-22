    public interface IMessageSender
    {
        void Send( string message, string destination );
    }
    public class TextClient : IMessageSender { ... }
    public class MailClient : IMessageSender { ... }
