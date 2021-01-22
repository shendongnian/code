    if (Membership.ValidateUser(Username.Text, Password.Text))
    {
       FormsAuthentication.SetAuthCookie(Username.Text, false);
       FormsAuthentication.RedirectFromLoginPage(Username.Text, false);
    }
    else
    {
    // do something else
    }
