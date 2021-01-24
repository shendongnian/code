    class LoginController
    {
        ILoginView loginView;
        public LoginController(ILoginView loginView)
        {
            this.loginView = loginView;
        }
        public async Task<bool> Login()
        {
            loginView.ShowDialog();
            bool result = await DoYourLoginProcedure(loginView.Login, loginView.Pass);
            if(result)
            {
               loginView.Hide(); //or possibly Dispose
            }
        }
    }
