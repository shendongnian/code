    public class EditAccountPresenter
    {
        private readonly IEditAccountView _view;
        private readonly IAccountRepository _accounts;
        public EditAccountPresenter(IEditAccountView view, IAccountRepository accounts)
        {
            _view = view;
            _accounts = accounts;
            _view.DataBinding += OnDataBinding;
        }
        private void OnDataBinding(object sender, EventArgs e)
        {
            _view.Account = _accounts.GetById(234);
        }
    }
