    using(LoginPage page = new LoginPage())
    {
          page.UsernameTextBox().SetText("Administrator");
          page.PasswordTextBox().SetText("Password12121212");
          page.SubmitButton().Click();
    }
