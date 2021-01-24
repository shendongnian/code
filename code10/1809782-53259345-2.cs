    public DelegateCommand LoginCommand { get; }
    private bool canLogin = true;
    public LoginViewModel(ILoginAuth loginAuth)
    {
        LoginCommand = new DelegateCommand(LoginUser, () => canLogin);
    }
    public void LoginUser()
    {
        canLogin = false;
        LoginCommand.RaiseCanExecuteChanged();
    }
