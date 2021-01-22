    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      LoginForm loginForm = new LoginForm();
      Application.Run(loginForm);
      if (loginForm.IsLoggedIn)
      {
        Application.Run(new OtherForm());
      }
    }
