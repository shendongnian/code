    public class AccountViewModelFactory : IAccountViewModelFactory
    {
        public AccountViewModelFactory(IAccountService accountService)
        {
            AccountService = accountService;
        }
    
        public IAccountService AccountService { get; }
    
        public AccountViewModel Create(AccountModel model)
        {
            return new AccountViewModel(AccountService, model);
        }
    }
