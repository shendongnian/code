    using (var context = new PrincipalContext(ContextType.Domain, LDAP_DOMAIN, "service_acct_user", "service_acct_pswd")) {
        if (context.ValidateCredentials(username, password)) {
            using (var de = new DirectoryEntry(LDAP_PATH))
            using (var ds = new DirectorySearcher(de)) {
                ds.PropertiesToLoad.Add("memberof");
                ds.Filter = $"(& (objectClass=person)(|(cn={username})))";
                var result = ds.FindOne();
                if (result != null) {
                    var roles = result.Properties["memberof"]
                        .Cast<string>()
                        .Select(x => regexRoles.Match(x))
                        .Where(m => m.Success && m.Groups.Count > 0)
                        .Select(m => m.Groups[1].Value.ToLowerInvariant());
                            
                    if (roles.Contains("target_group")) {
                        // User authenticated and authorized
                        var identities = new List<ClaimsIdentity> { new ClaimsIdentity("custom auth type") };
                        var ticket = new AuthenticationTicket(new ClaimsPrincipal(), Options.Scheme);
                        return Task.FromResult(AuthenticateResult.Success(ticket));
                    }
                }
            }
        }
    }
    // User not authenticated
    return Task.FromResult(AuthenticateResult.Fail("Invalid auth key."));
