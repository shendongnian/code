    public class AccountViewModel
    {
        public AccountViewModel(IAccountService accountService, AccountModel model)
        {
            AccountService = accountService;
            Model = model;
        }
    
        public IAccountService AccountService { get; }
        public AccountModel Model { get; }
    }
