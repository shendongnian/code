    ICommand _loginNav;
    public ICommand NavigatePopup
    {
        get
        {
            if (_loginNav == null)
            {
                _loginNav = new Command(async () => await NavigateModalLogin());
            }
            return _loginNav;
        }
    }
    async Task NavigateModalLogin()
    {
        await _navService.PushModalAsync<NormalModalViewModel>();
    }
