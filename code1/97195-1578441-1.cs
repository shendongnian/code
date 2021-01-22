    private void Login(string username, string password)
    {
         if (username != DBUsername && password != DBPassword)
         {
              throw new LoginFailedException("Login details are incorrect");
         }
         // else login...
    }
    private void ButtonClick(object sender, EventArgs e)
    {
         try
         {
               Login(txtUsername.Text, txtPassword.Text);
         }
         catch (LoginFailedException ex)
         {
               // handle exception.
         }
    }
