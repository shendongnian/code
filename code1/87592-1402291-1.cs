            <authentication mode="Forms">
                  <forms loginUrl="~/Account/LogOn" timeout="10"/>
            </authentication>                  
    
     public bool ValidateUser(string userName, string password)
            {
                bool validation;
                try
                {
                    LdapConnection ldc = new LdapConnection(new LdapDirectoryIdentifier((string)null, false, false));
                    NetworkCredential nc = new NetworkCredential(userName, password, "DOMAIN NAME HERE");
                    ldc.Credential = nc;
                    ldc.AuthType = AuthType.Negotiate;
                    ldc.Bind(nc); // user has authenticated at this point, as the credentials were used to login to the dc.
                    validation = true;
                }
                catch (LdapException)
                {
                    validation = false;
                }
                return validation;
            }
