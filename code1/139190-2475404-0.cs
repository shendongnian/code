    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    
        if (PerformLogin())
        {           
            Application.Run(new MainForm());
        }
    }
    
    private static bool PerformLogin()
    {
        using (LoginForm loginForm = new LoginForm())
        {
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                return AuthenticateUser(loginForm.UserName, loginForm.Password);
            }
            else
            {
                return false;
            }
        }
    }
