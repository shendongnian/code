    string firstName = txtFirstName.Text;
    string lastName = txtLastName.Text;
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    UserPrincipal up = new UserPrincipal(ctx);
    if (!String.IsNullOrEmpty(firstName))
        up.GivenName = firstName;
    if (!String.IsNullOrEmpty(lastName))
        up.Surname = lastName;
    PrincipalSearcher srch = new PrincipalSearcher(up);
    srch.QueryFilter = up;
