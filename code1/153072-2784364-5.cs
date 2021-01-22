    public class AccountManager
    {
        public IList<Account> Accounts { get; private set; }
        public AccountManager()
        {
            // here in the constructor, Accounts is SET to a List<Account>;
            // however, code that interacts with the Accounts property will
            // only know that it's interacting with something that implements
            // IList<Account>
            Accounts = new List<Account>();
        }
    }
