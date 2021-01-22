    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    
        LoginForm login = new LoginForm();
        
        if (login.ShowDialog() == DialogResult.OK &&
            login.ValidLogin == 1)
        Application.Run(new PROG1());
    }
