    private IUser GetUser(){
    
    string username = FormatText(txtUsername.Text)
    string password = FormatText(txtPassword.Text);
    string email = FormatText(txtEmail.Text);       
    int userPK = Int32.Parse(txtUserPK.Text.ToString());
    string status = ddlStatus.SelectedValue.Trim();
    IUser user = UserFactory.getInstance().createUser(userPK, username, password, email,status);
    return user;
    
    }
    
    private string FormatText(string input)
    {
       return input.Trim().ToLower();
    
    }
