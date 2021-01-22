    OpenIdRelyingParty openid = new OpenIdRelyingParty();
    var response = openid.GetResponse();
    if (response != null)
    {
        switch (response.Status)
        {
            case AuthenticationStatus.Authenticated:
            {
                var fetch = response.GetExtension<FetchResponse>();
                string email = string.Empty();
                if (fetch != null)
                {
                    email =  fetch.GetAttributeValue(
                        WellKnownAttributes.Contact.Email);
                }
                FormsAuthentication.RedirectFromLoginPage(
                    response.ClaimedIdentifier, false);
                break;
            }
            ...
        }
    }
