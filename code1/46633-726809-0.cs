    public class StubRemotingHandler : IRemotingHandler
    {
        public CustomerContact savedContact;
        public void SaveCustomerContact(ref CustomerContact contact)
        {
            savedContact = contact;
        }
    }
