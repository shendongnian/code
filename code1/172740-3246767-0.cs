    public interface IMessageClient
    {
        public void Send(string text, string destination);
    }
    public class TextClient : IMessageClient
    {
        public void Send(string text, string destination)
        {
            // send text message
        }
    }
    public class MailClient : IMessageClient
    {
        public void Send(string text, string destination)
        {
            // send email
        }
    }
    public class ClassA
    {
        private IMessageClient client;
        public ClassA(IMessageClient client)
        {
            this.client = client;
        }
    }
