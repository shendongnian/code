    //The Request
     using (OpenIdRelyingParty openid = new OpenIdRelyingParty())
     {
       IAuthenticationRequest request = openid.CreateRequest(openidurl);
        var fetch = new FetchRequest();
        fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
        request.AddExtension(fetch);
        
        // Send your visitor to their Provider for authentication.
        request.RedirectToProvider();
     }
    //The Response
     OpenIdRelyingParty openid = new OpenIdRelyingParty();
     var response = openid.GetResponse();
     if (response != null)
     {
             switch (response.Status)
             {
                 case AuthenticationStatus.Authenticated:
    
                 var fetch = response.GetExtension<FetchResponse>();
                 string email = string.Empty(); 
                 if (fetch != null)
                 {
                    email =  fetch.GetAttributeValue(WellKnownAttributes.Contact.Email)
                 }  
                                         
                 FormsAuthentication.RedirectFromLoginPage(response.ClaimedIdentifier, false);
              break;
              }
    }
