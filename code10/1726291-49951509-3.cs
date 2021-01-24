    protected void Page_Load(object sender, EventArgs e)
    {
    	bool isLoggedIn = false;
    	string email = string.Empty;
    	string password = string.Empty;
    	if (IsPostBack)
    	{
    		email = txtEmail.Text;
    		password = txtPassword.Text;
    
    		isLoggedIn = IsValidLoginCredentials(email, password);
    
    		if (isLoggedIn)
    		{
    			Session.Add("email", email);
    			Boolean checkUserType = checkUser(email, password);
    
    			if (checkUserType)
    				Response.Redirect("~/Pages/AdminDefault.aspx");
    
    			else
    				Response.Redirect("~/Pages/Default.aspx");
    		}
    		else
    		{
    			lblLoginDetails.Text = "Invalid Login Details - please try again!";
    		}
    	}
    }
