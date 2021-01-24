    public interface IMessageProcessor
    {
        ProcessCustomerPhoneContactInfo(Contact currentPhoneContact);
    }
    public class MessageProcessor : IMessageProcessor
    {
        public void ProcessCustomerPhoneContactInfo(Contact currentPhoneContact)
        {
            // implementation
        }
    }
