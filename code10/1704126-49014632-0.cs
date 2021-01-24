        using System.Security.Cryptography.X509Certificates;
        using System.Net.Security;
        // Validate the server certificate.
		ServicePointManager.ServerCertificateValidationCallback =
		delegate(object sender,
				 X509Certificate certificate,
				 X509Chain chain,
				 SslPolicyErrors sslPolicyErrors)
		{ return true; };
