    private void Login_OnClick(object sender, EventArgs e)
    {
          UserDetails user = new UserDetails(txtusername.Text,txtPassword.Text);
          if(SecurityManager.IsValiduser(user))
          {
               ///Ok let them in;;;
          }
    
    }
