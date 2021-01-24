    // This answer assumes that this class is an domain entity.
    public class UserAccount
    {
        public Guid Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Message(IAccountService accountService)
        {
            if (accountService == null) throw new ArgumentNullException(nameof(accountService));
    
            return accountService.Message();
        }
    }
