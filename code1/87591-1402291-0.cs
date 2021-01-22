           <connectionStrings>
                <add name="ADConnectionString" connectionString="connectionString="LDAP://servername:port#/DC=domainname"/>
    </connectionStrings>
        
            <authentication mode="Forms">
                  <forms loginUrl="~/Account/LogOn" timeout="10"/>
            </authentication>
        
            <membership defaultProvider="DomainLoginMembershipProvider">
                  <providers>
                    <add name="DomainLoginMembershipProvider"
                         type="System.Web.Security.ActiveDirectoryMembershipProvider, System.Web, Version=2.0.0.0,Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                         connectionStringName="ADConnectionString"
                         connectionProtection="Secure"             
                         attributeMapUsername="sAMAccountName"
                         enableSearchMethods="false"/>
                  </providers>
                </membership>
    
    
    
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
