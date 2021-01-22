    using( MailMessage message = new MailMessage() )
    {
    	message.To.Add( "none@none.com" );
    	message.Subject = "Here's your new password";
    	message.IsBodyHtml = true;
    	message.Body = GetEmailTemplate();
    
    	// Replace placeholders in template.
    	message.Body = message.Body.Replace( "<%Password%>", newPassword );
    	message.Body = message.Body.Replace( "<%LoginUrl%>", HttpContext.Current.Request.Url.GetLeftPart( UriPartial.Authority ) + FormsAuthentication.LoginUrl ); // Get the login url without hardcoding it.
    
    	new SmtpClient().Send( message );
    }
    private string GetEmailTemplate()
    {
    	string templatePath = Server.MapPath( @"C:\template.rtf" );
    
    	using( StreamReader sr = new StreamReader( templatePath ) )
    		return sr.ReadToEnd();
    }
