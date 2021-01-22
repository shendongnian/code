    void RedirectToAdmin()
    {
        Response.Redirect(ConfigurationManager.AppSettings["AdminLink"], true);
    }
    void ShowJsMessageBox(bool success, string succesMessage, string failedMessage)
    {
        jsMsgBox(success ? succesMessage : failedMessage);
    }
    void SaveUserFromControlInfo(bool isInsert)
    {
        string username = txtUsername.Text.Trim().ToLower();
        string password = txtPassword.Text.Trim().ToLower();
        string email = txtEmail.Text.Trim().ToLower();
        string status = ddlStatus.SelectedValue.Trim();
        var userFactory = UserFactory.getInstance();
        IUser user;
        if( isInsert )
            user = userFactory.createUser(username, password, email, status);
        else
        {
            int userPK = Int32.Parse(txtUserPK.Text);
            user = userFactory.createUser(userPK, username, password, email, status);
        }
        return user.save();
    }
