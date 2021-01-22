.
.
.
.
        protected void btnAdd_Click(object sender, EventArgs e) { SaveUser();}
        protected void btnUpdate_Click(object sender, EventArgs e) { SaveUser();}
        private void SaveUuser()
        {
              UserFactory.save(txtUsername.Text, txtPassword.Text, 
                              txtEmail.Text, ddlStatus.SelectedValue);  
              jsMsgBox("Successfully added new user");            
              Response.Redirect(
                  ConfigurationManager.AppSettings["AdminLink"], true);         
        }
      
    static class MyWebPage:  System.Web.UI.Page     {
        static void Page_Load() // Main ASP.Net entry point (whatever that is... 
        {
             try 
             {
                 // opening screen winform class
                 Application.Run(new MyMainWinForm());  
             }
             catch(MyMainCustomApplicationException X)
             {
                 jsMsgBox("An Error was encountered while " +
                          "trying to add a new user.");        
                 lblInfo.Text = X.Message;        
                 lblInfo.Visible = true;
             }
             catch(Exception eX) 
             {  
                  // Maybe Log it here...
                  throw;   // Important to retrhow all unexpected exceptions to
                           // MAKE web page crash !! as you have no idea
                           // whether web app is in consistent state now.
             }
        }
    }
