    bool issuccess = false;
    string username = GetloggedinUserName();
    if (username.ToLowerInvariant().Contains(txtUserName.Text.Trim().ToLowerInvariant()) && username.ToLowerInvariant().Contains(txtDomain.Text.Trim().ToLowerInvariant()))
    	{
    		issuccess = IsValidateCredentials(txtUserName.Text.Trim(), txtPwd.Text.Trim(), txtDomain.Text.Trim());
    	}
    
    if (issuccess)
    	MessageBox.Show("Successfuly Login !!!");
    else
    	MessageBox.Show("User Name / Password / Domain is invalid !!!");
