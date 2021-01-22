            // Creating an LdapConnection instance 
            LdapConnection ldapConn = new LdapConnection();
            ldapConn.SecureSocketLayer = true;
            ldapConn.UserDefinedServerCertValidationDelegate += new
                    CertificateValidationCallback(MySSLHandler);
            //Connect function will create a socket connection to the server
            ldapConn.Connect(ldapHost, ldapPort);
            //Bind function will Bind the user object Credentials to the Server
            ldapConn.Bind(userDN, userPasswd);
            // Searches in the Marketing container and return all child entries just below this
            //container i.e. Single level search
            LdapSearchResults lsc = ldapConn.Search("ou=users,o=uga",
                               LdapConnection.SCOPE_SUB,
                               "objectClass=*",
                               null,
                               false);
            while (lsc.hasMore())
            {
                LdapEntry nextEntry = null;
                try
                {
                    nextEntry = lsc.next();
                }
                catch (LdapException e)
                {
                    Console.WriteLine("Error: " + e.LdapErrorMessage);
                    // Exception is thrown, go for next entry
                    continue;
                }
                Console.WriteLine("\n" + nextEntry.DN);
                LdapAttributeSet attributeSet = nextEntry.getAttributeSet();
                System.Collections.IEnumerator ienum = attributeSet.GetEnumerator();
                while (ienum.MoveNext())
                {
                    LdapAttribute attribute = (LdapAttribute)ienum.Current;
                    string attributeName = attribute.Name;
                    string attributeVal = attribute.StringValue;
                    Console.WriteLine(attributeName + "value:" + attributeVal);
                }
            }
            ldapConn.Disconnect();
            Console.ReadKey();
        }
    public static bool MySSLHandler(Syscert.X509Certificate certificate,
                int[] certificateErrors)
            {
    
                X509Store store = null;
                X509Stores stores = X509StoreManager.CurrentUser;
                //string input;
                store = stores.TrustedRoot;
    
                X509Certificate x509 = null;
                X509CertificateCollection coll = new X509CertificateCollection();
                byte[] data = certificate.GetRawCertData();
                if (data != null)
                    x509 = new X509Certificate(data);
    
                return true;
            }
