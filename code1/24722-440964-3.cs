    // Create Connection
                    LdapConnection conn = new LdapConnection();
                    conn.SecureSocketLayer = true;
                    Response.Write("Connecting to:" + ldapHost);
    
                    conn.UserDefinedServerCertValidationDelegate += new
                        CertificateValidationCallback(MySSLHandler);
    
                    if (bHowToProceed == false)
                        conn.Disconnect();
                    if (bHowToProceed == true)
                    {
                        conn.Connect(ldapHost, ldapPort);
                        conn.Bind(loginDN, password);
                        Response.Write(" SSL Bind Successfull ");
    
                        conn.Disconnect();
                    }
                    quit = false;
