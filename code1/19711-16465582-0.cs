		[TestMethod]
        public void CreateUserAccount()
        {
            var username = "amurray";
            var password = "ADAMComplexPassword1234";
            var firstname = "Andy";
            var lastname = "Murray";
            const AuthenticationTypes authTypes = AuthenticationTypes.Signing |
                                                  AuthenticationTypes.Sealing |
                                                  AuthenticationTypes.Secure;
            var ldapPath = "LDAP://localhost:389/OU=MyProject,OU=Applications,DC=Company,DC=ADAM";
            using (var dirEntry = new DirectoryEntry(ldapPath, "MyPC\\adamuser", "Password1!", authTypes))
            {
                DirectoryEntry user = null;
				const int ADS_PORT = 389;
				const long ADS_OPTION_PASSWORD_PORTNUMBER = 6;
				const long ADS_OPTION_PASSWORD_METHOD = 7;
				const int ADS_PASSWORD_ENCODE_CLEAR = 1;
				
                try
                {
                    user = dirEntry.Children.Add(string.Format("CN={0} {1}", firstname, lastname), "user");
                    user.Properties["displayName"].Value = username;
                    user.Properties["userPrincipalName"].Value = username;
                    user.Properties["msDS-UserAccountDisabled"].Value = false;
                    user.Properties["msDS-UserDontExpirePassword"].Value = true;
                    user.CommitChanges();
                    var userid = user.Guid.ToString();
                    // Set port number, method, and password.
                    user.Invoke("SetOption", new object[]{ADS_OPTION_PASSWORD_PORTNUMBER,ADS_PORT});
                    user.Invoke("SetOption", new object[]{ADS_OPTION_PASSWORD_METHOD,ADS_PASSWORD_ENCODE_CLEAR});
                    user.Invoke("SetPassword", new object[] {password});
                    user.CommitChanges();
					user.Close();
                }
                catch (Exception e)
                {
                    var msg = e.GetBaseException().Message;
                    Console.WriteLine(e);
                    System.Diagnostics.Debug.Print(msg);
                }                
            }
        }
		[TestMethod]
        public void TestUserAuthentication()
        {
            try
            {
                var ldsContext = new PrincipalContext(ContextType.ApplicationDirectory, "localhost:389",
                                                      "OU=MyProject,OU=Applications,DC=Company,DC=ADAM",
                                                      ContextOptions.SimpleBind);
				// Returns true if login details are valid
                var isValid = ldsContext.ValidateCredentials("amurray", "ADAMComplexPassword1234", ContextOptions.SimpleBind);
            }
            catch (Exception e)
            {
                var msg = e.GetBaseException().Message;
                Console.WriteLine(e);
                System.Diagnostics.Debug.Print(msg);
            }
        }
