    protected void btnAdd_Click(object sender, EventArgs e)
    {
        UserInfo myUser = GetUserInfo();
        try
        {
            IUser user = UserFactory.getInstance().createUser(myUser);
    
            if (user.save())
            {
                jsMsgBox("Successfully added new user");
                Response.Redirect(ConfigurationManager.AppSettings["AdminLink"], true);
            }
            else
            {
                jsMsgBox("An error was encountered while trying to add a new user.");
            }
        }
        catch (Exception ex)
        {
            jsMsgBox("An Error was encountered while trying to add a new user.");
            lblInfo.Text = ex.Message;
            lblInfo.Visible = true;
        }
    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UserInfo myUser = GetUserInfo();
        int userPK = Int32.Parse(txtUserPK.Text.ToString());
        
        try
        {       
            IUser user = UserFactory.getInstance().createUser(userPK,myUser);
    
            if (user.save())
            {
                jsMsgBox("Successfully updated selected users information.");
                Response.Redirect(ConfigurationManager.AppSettings["AdminLink"], true);
            }
            else
            {
                jsMsgBox("An error was encountered while trying to update the selected users information.");
            }
        }
        catch (Exception ex)
        {
            jsMsgBox("An Error was encountered while trying to update the selected users information.");
            lblInfo.Text = ex.Message;
            lblInfo.Visible = true;
        }
    }
    
    private UserInfo GetUserInfo()
    {
        UserInfo myUser = new UserInfo();
       
        UserInfo.username = txtUsername.Text.Trim().ToLower();
        UserInfo.password = txtPassword.Text.Trim().ToLower();
        UserInfo.email = txtEmail.Text.Trim().ToLower();
        UserInfo.status = ddlStatus.SelectedValue.Trim();
    
        return myUser;
    }
