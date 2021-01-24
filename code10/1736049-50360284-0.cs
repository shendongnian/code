    public ActionResult TestView()
    {
        bool isAuthenticated;
        var base64Header = Request.Headers["Authorization"];
        //The header is a string in the form of "Basic [base64 encoded username:password]"
        if (base64Header != null)
        {
            var authHeader = AuthenticationHeaderValue.Parse(base64Header);
            if (authHeader != null
                && authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase)
                && authHeader.Parameter != null)
            {
                //Decode the username:password pair
                var credentialPair = Encoding.ASCII.GetString(Convert.FromBase64string(authHeader.Parameter));
                //Split into pieces
                var credentials = credentialPair.Split(new [] {":"}, StringSplitOptions.None);
                var userName = credentials[0];
                var plainTextPassword = credentials[1];
                isAuthenticated = SomeAuthenticator.Authenticate(userName, password);
            }
        }
        if (isAuthenticated)
           return Foo();
        else
           RedirectResult("your login view");
    }
