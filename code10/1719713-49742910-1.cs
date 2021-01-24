    using (var context = new PrincipalContext(ContextType.Domain, LDAP_DOMAIN, "service_acct_user", "service_acct_pswd")) {
        if (context.ValidateCredentials(username, password)) {
            using (var de = new DirectoryEntry(LDAP_PATH))
            using (var ds = new DirectorySearcher(de)) {
                // other logic to verify user has correct permissions
                            
                // User authenticated and authorized
                var identities = new List<ClaimsIdentity> { new ClaimsIdentity("custom auth type") };
                var ticket = new AuthenticationTicket(new ClaimsPrincipal(), Options.Scheme);
                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
        }
    }
    // User not authenticated
    return Task.FromResult(AuthenticateResult.Fail("Invalid auth key."));
