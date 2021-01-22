    protected string cleaned(string raw) {
        raw.Text.Trim().ToLower()
        }
    protected void attempt_to_save(IUser user, string task) {
        if (user.save()) {
            jsMsgBox("Successfully finished "+task);
            Response.Redirect(ConfigurationManager.AppSettings["AdminLink"], true);
          } else {
            jsMsgBox("An error was encountered while "+task);
            }
        }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            IUser user = UserFactory.getInstance().createUser(
                cleaned(txtUsername), 
                cleaned(txtPassword), 
                cleaned(txtEmail),
                ddlStatus.SelectedValue.Trim()
                );
    
            attempt_to_save(user,"adding a new user.");
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
        try
        {
    
            IUser user = UserFactory.getInstance().createUser(
                Int32.Parse(txtUserPK.Text.ToString()), 
                cleaned(txtUsername), 
                cleaned(txtPassword), 
                cleaned(txtEmail),
                ddlStatus.SelectedValue.Trim()
                );
    
            attempt_to_save(user,"updating the selected users information.");
            }
        }
        catch (Exception ex)
        {
            jsMsgBox("An Error was encountered while trying to update the selected users information.");
            lblInfo.Text = ex.Message;
            lblInfo.Visible = true;
        }
    }
