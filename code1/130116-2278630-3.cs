    public class EditAccountPresenter
    {
        private readonly IEditAccountView _view;
        private readonly IAccountRepository _accounts;
        public EditAccountPresenter(IEditAccountView view, IAccountRepository accounts)
        {
            _view = view;
            _accounts = accounts;
            _view.Initializing += OnInitializing;
        }
        private void OnInitializing(object sender, EventArgs e)
        {
            _view.BindAccount(_accounts.GetById(234));
        }
    }
