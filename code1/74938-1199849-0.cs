    // pseudocode, because I do not know WinForms that much
    class MainController
    {
        private Guid securityToken;
        
        public Guid SecurityToken
        {
            get { return securityToken; }
            
            set { securityToken = value; }
        }
    }
    
    class LoginWindowController
    {
        MainController mainController;
        LoginWindow    loginWindow;
        
        public LoginWindowController(MainController mainController)
        {
            this.loginWindow    = new LoginWindow(this);
            this.mainController = mainController;
        }
        
        public void Show()
        {
            loginWindow.IsVisible = true;
        }
    
        public void HandleLogin()
        {
            Guid token = 
                myobject.Authenticate(loginWindow.Username, loginWindow.Password);
            
            if (token != Guid.Empty)
            {
                mainController.SecurityToken = token;
            }   
        }
    }
