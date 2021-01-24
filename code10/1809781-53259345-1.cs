    public DelegateCommand LoginCommand { get; }
    private bool canLogin = true;
    public LoginViewModel(ILoginAuth loginAuth)
    {
        LoginCommand = new DelegateCommand(LoginUser, p => canLogin);
    }
    public void LoginUser(object p)
    {
        canLogin = false;
        LoginCommand.RaiseCanExecuteChanged();
    }
