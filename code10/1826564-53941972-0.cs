    public class AccountModel
    {
        public int Id { get; set; }
        // some more properties
    }
    public interface IAccountService
    {
        Task<AccountModel> GetByIdAsync(int id);
    }
    public class AccountViewModel
    {
        public AccountViewModel(IAccountService accountService)
        {
            AccountService = accountService;
        }
        protected IAccountService AccountService { get; }
        private Task LoadFromModelAsync(AccountModel model)
        {
            Id = model.Id;
            _originalModel = model;
            return Task.CompletedTask;
        }
        private AccountModel _originalModel;
        public int Id { get; private set; }
        public async Task InitializeAsync(object parameter)
        {
            switch (parameter)
            {
                case null:
                    await LoadFromModelAsync(new AccountModel());
                    break;
                case int id:
                    {
                        var model = await AccountService.GetByIdAsync(id);
                        await LoadFromModelAsync(model);
                        break;
                    }
                case AccountModel model:
                    await LoadFromModelAsync(model);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
