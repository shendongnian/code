    protected void btnAdd_Click(object sender, EventArgs e) { SaveUser();}
    protected void btnUpdate_Click(object sender, EventArgs e) { SaveUser();}
    private void SaveUser()
    {
          int? userId = string.IsNullOrEmpty(txtUserPK.Text)? null:
                       Int32.Parse(txtUserPK.Text.ToString());
          UserFactory.Save(userId , txtUsername.Text, txtPassword.Text, 
                          txtEmail.Text, ddlStatus.SelectedValue);  
          jsMsgBox("Successfully added new user");            
          Response.Redirect(
              ConfigurationManager.AppSettings["AdminLink"], true);         
    }
