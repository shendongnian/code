        var cookie = FormsAuthentication.GetAuthCookie(name, rememberMe);
        var ticket = FormsAuthentication.Decrypt(cookie.Value);
        var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration,ticket.IsPersistent, userData, ticket.CookiePath);
        var encTicket = FormsAuthentication.Encrypt(newTicket);
        cookie.Value = encTicket;
        //and add the cookie to the current HttpContext.Response
        response.Cookies.Add(cookie);
