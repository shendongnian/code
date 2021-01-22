    HttpContext context = HttpContext.Current;
    
    //overwrite the authentication cookie
    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, context.User.Identity.Name, DateTime.Now, DateTime.Now.AddDays(-1), false, Guid.NewGuid().ToString());
    string encrypted_ticket = FormsAuthentication.Encrypt(ticket);
    
    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted_ticket);
    cookie.Expires = ticket.Expiration;
    context.Response.Cookies.Add(cookie);
    
    //clear all the sessions
    context.Session.Abandon();
    
    //sign out and go to the login page
    FormsAuthentication.SignOut();
    FormsAuthentication.RedirectToLoginPage();
