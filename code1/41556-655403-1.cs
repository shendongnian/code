    private IUser GetUser(){
    
    string username = FormatText(txtUsername.Text)
    string password = FormatText(txtPassword.Text);
    string email = FormatText(txtEmail.Text);       
    string status = ddlStatus.SelectedValue.Trim();
    if(txtUserPK.Text!=string.empty){
    int userPK = Int32.Parse(txtUserPK.Text);
    IUser user = UserFactory.getInstance().createUser(userPK, username, password, 
    email,status);
    }
    else
    {
    
     IUser user = UserFactory.getInstance().createUser(username, password, email,status);
    
    
    }
    return user;
    
    }
    
    private string FormatText(string input)
    {
       return input.Trim().ToLower();
    
    }
