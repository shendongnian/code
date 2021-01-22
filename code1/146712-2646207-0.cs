    var user = context.Users.Where(u => u.Username==TextBoxLoginUsername.Text && 
                                        u.Password == TextBoxLogInPassword.Text)
                   .FirstOrDefault();
    string userNameCheck = user.Username;
    string passwordCheck = user.Password;
