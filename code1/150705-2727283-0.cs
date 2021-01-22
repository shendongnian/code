    public FormMain()
    {
        InitializeComponent();
        //Visible should be set within InitializeComponent (or Designer)
        Visible = false;
        //Can't be done in constructor, or this.Close()
        //would lead to an exception.
        this.Load += (sender, e) =>
        {
            bool loginSuccessfull = false;
            using (var loginScreen = new FormLogin())
            {
                if (DialogResult.OK == loginScreen.ShowDialog())
                {
                    //Maybe some other public function from loginScreen
                    //is needed to determine if the login was successfull
                    //loginSuccessfull = loginScreen.CheckCredentials();
                    loginSuccessfull = true;
                }
            }
            if (loginSuccessfull)
            {
                Visible = true;
            }
            else
            {
                this.Close();
            }
        };
    }
