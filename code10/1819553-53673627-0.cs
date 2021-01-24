    X509Certificate2 cert = null;
    try
    {
    	if (OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets.Count > 0)
    	{
    		cert = ((X509CertificateClaimSet)OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0]).X509Certificate;
    	}
    	else
    	{
    		throw new Exception("missing cert...");
    	}
    }
    catch (Exception ex)
    {
    	//log something and handle exception
    }
