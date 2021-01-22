    LdapConnection Connection = new LdapConnection();
		Connection.SecureSocketLayer = true;
		Connection.UserDefinedServerCertValidationDelegate += new
				Novell.Directory.Ldap.RemoteCertificateValidationCallback(LdapSSLHandler);
		public bool LdapSSLHandler(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain,
					  System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == sslPolicyErrors.None)
            {
                return true;   //Is valid
            }
            if (certificate.GetCertHashString() == "YOUR CERTIFICATE HASH KEY") // Thumbprint value of the certificate
            {
                return true;
            }
            return false;
        }
