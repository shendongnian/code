    private int validateUserActiveDirectory()
    {
        IntPtr token = IntPtr.Zero;
        int DBgroupLevel = 0;
       
        // make sure you're yourself -- recommended at msdn http://support.microsoft.com/kb/248187
        RevertToSelf();
       
        if (LogonUser(txtUserName.Value, propDomain, txtUserPass.Text, LOGON32_LOGON_NETWORK, LOGON32_PROVIDER_DEFAULT, token) != 0) {
            // ImpersonateLoggedOnUser not required for us -- we are not doing impersonated stuff, but leave it here for completeness.
            //ImpersonateLoggedOnUser(token);
            // do impersonated stuff
            // end impersonated stuff
           
            // ensure that we are the original user
            CloseHandle(token);
            RevertToSelf();
           
            System.Security.Principal.IdentityReferenceCollection groups = Context.Request.LogonUserIdentity.Groups;
            IdentityReference translatedGroup = default(IdentityReference);
           
            foreach (IdentityReference g in groups) {
                translatedGroup = g.Translate(typeof(NTAccount));
                if (translatedGroup.Value.ToLower().Contains("desired group")) {
                    inDBGroup = true;
                    return 1;
                }
            }
        }
        else {
            return 0;
        }
    }
