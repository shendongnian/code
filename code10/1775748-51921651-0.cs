    // This should be public to be callable from the usercontrol
    public void ShowLogIn()
    {
        if (this.mnuLogIn.Text == "LogOut" )
        {
            if (MessageBox.Show("Are you sure you want to LogOut?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                 mnuLogIn.Text = "LogIn";
                 ShowMenu("");
                 // Call the user control to adjust its internal status
                 obj_uc_MainMenu.SetLoginStatus();
            }
       }
       else
       {
           using(frmLogin obj_frmLogin = new frmLogin())
           {
                // Check the username and password and if everythin ok then
                mnuLogIn.Text = "LogOut";
                // Again call the usercontrol to adjust its status
                obj_uc_MainMenu.SetLogoutStatus()
           }
       }
    }
    public void SetLoginStatus()
    {
        btnLogIn.Text = "LOGIN"; 
    }
    public void SetLogoutStatusStatus()
    {
        btnLogIn.Text = "LOGOUT"; 
    }
    private void btnLogIn_Click(object sender, EventArgs e)
    {
        // Get the current instance of frmMain from the OpenForms collection
        frmMain obj_frmMain = Application.OpenForms.OfType<frmMain>();           
        // Should not be required, but better to be safe....
        if(obj_frmMain != null) 
           // Call the public method to run the login process
           obj_frmMain.ShowLogin();
    }
    
