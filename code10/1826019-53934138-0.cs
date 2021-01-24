	protected void btnLogin_Click(object sender, EventArgs e)
	{
		string username = txtUsername.Text;
		string password = txtPassword.Text;
		bool rememberUsername = false;
		SqlDbAccess db = new SqlDbAccess();
		int result = db.ValidateLogin(username, password);
		switch (result)
		{
			case -1:
				lblValidationError.Text = "Utilizador / Password incorrecto";
				break;
			case -2:
				lblValidationError.Text = "Conta desactivada";
				break;
			default:
				// not certain what should be passed in here???
				string roles = db.GetRoles(username);
				var ticket = new FormsAuthenticationTicket
				(
					1, 
					username, 
					DateTime.Now, 
					DateTime.Now.AddMinutes(20), 
					rememberUsername, 
					roles, 
					FormsAuthentication.FormsCookiePath
				);
				string hashCookies = FormsAuthentication.Encrypt(ticket);
				HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies);
				Response.Cookies.Add(cookie);
				FormsAuthentication.RedirectFromLoginPage(username, rememberUsername);
				break;
		}
	}
