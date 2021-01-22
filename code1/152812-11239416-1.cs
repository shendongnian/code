    public void btnLogin_Click(UserLoginViewModel model)
    {
        bool ValidLogin = false; // this is our "result value"
        try
        {
            using (Context Db = new Context)
            {
                User User = new User();
                if (String.IsNullOrEmpty(model.EmailAddress))
                    ValidLogin = false; // no email address was entered
                else
                    User = Db.FirstOrDefault(x => x.EmailAddress == model.EmailAddress);
                if (User != null && User.PasswordHash == Hashing.CreateHash(model.Password))
                    ValidLogin = true; // login succeeded
            }
        }
        catch (Exception ex)
        {
            throw ex; // something went wrong so throw an error
        }
        if (ValidLogin)
        {
            GenerateCookie(User);
            Response.Redirect("~/Members/Default.aspx");
        }
        else
        {
            // do something to indicate that the login failed.
        }
    }
