    bool bReturn = false;
    string sDomainName = System.Environment.UserDomainName;
    using (PrincipalContext oContext = new     PrincipalContext(ContextType.Domain, sDomainName))
    {
    if (oContext.ValidateCredentials(sUserName, sPassword))
    {
        using (PrincipalSearcher oSearcher = new PrincipalSearcher(new UserPrincipal(oContext)))
        {
            oSearcher.QueryFilter.SamAccountName = sUserName;
            Principal oPrincipal = oSearcher.FindOne();
            foreach (Principal oPrin in oPrincipal.GetGroups())
            {
                if (oPrin.Name.Trim().ToString().Equals(sGroupName))
                {
    				//your stuff here (assign vars, values etc)
                    bReturn = true; // <-- 
                }
            }
        }
    }
