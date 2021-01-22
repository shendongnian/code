    Dim loggedOutAfterInactivity As Integer = 999 'Minutes
    
    'Keep the session alive as long as the authentication cookie.
    Session.Timeout = loggedOutAfterInactivity
    
    'Get the authenticationTicket, decrypt and change timeout and create a new one.
    Dim formsAuthenticationTicketCookie As HttpCookie = _
            Response.Cookies(FormsAuthentication.FormsCookieName)
    
    Dim ticket As FormsAuthenticationTicket = _
            FormsAuthentication.Decrypt(formsAuthenticationTicketCookie.Value)
    Dim newTicket As New FormsAuthenticationTicket(
            ticket.Version, ticket.Name, ticket.IssueDate, 
            ticket.IssueDate.AddMinutes(loggedOutAfterInactivity), 
            ticket.IsPersistent, ticket.UserData)
    formsAuthenticationTicketCookie.Value = FormsAuthentication.Encrypt(newTicket)
