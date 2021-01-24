if (authCookie != null)
{
	FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
	if (authTicket != null && !authTicket.Expired)
	{
		var roles = authTicket.UserData.Split(',');
		
		var user = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
		
		HttpContext.Current.User = user;
		
		// Issue new ticket if there is less than 7 minutes remaining on current one.
		if ((authTicket.Expires - DateTime.Now) <= TimeSpan.FromMinutes(7)) 
		{
			var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(15), false, user.Roles);
			
     		string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
			
			var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
     		
			HttpContext.Response.Cookies.Add(authCookie);
		}
	}
}
