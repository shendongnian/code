    public static bool ManualSslVerification(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
    try
    {
    //Testing to see if the Certificate and Chain build properly, aka no forgery.
    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
    chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
    chain.Build(new X509Certificate2(certificate));
    
    //Looking to see if there are no errors in the build that we don’t like
    foreach (X509ChainStatus status in chain.ChainStatus)
    {
    if (status.Status == X509ChainStatusFlags.NoError || status.Status == X509ChainStatusFlags.UntrustedRoot)
    {
    //Acceptable Status, We want to know if it builds properly.
    }
    else
    {
    return false;
    }
    }
    
    X509Certificate2 trustedRootCertificateAuthority = new X509Certificate2(ViewController.Properties.Resources.My_Infrastructure_Root_CA);
    
    //Now that we have tested to see if the cert builds properly, we now will check if the thumbprint of the root ca matches our trusted one
    if(chain.ChainElements[chain.ChainElements.Count – 1].Certificate.Thumbprint != trustedRootCertificateAuthority.Thumbprint)
    {
    return false;
    }
    
    //Once we have verified the thumbprint the last fun check we can do is to build the chain and then see if the remote cert builds properly with it
    //Testing to see if the Certificate and Chain build properly, aka no forgery.
    X509Chain trustedChain = new X509Chain();
    trustedChain.ChainPolicy.ExtraStore.Add(trustedRootCertificateAuthority);
    trustedChain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
    trustedChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
    trustedChain.Build(new X509Certificate2(certificate));
    
    //Looking to see if there are no errors in the build that we don’t like
    foreach (X509ChainStatus status in trustedChain.ChainStatus)
    {
    if(status.Status == X509ChainStatusFlags.NoError || status.Status == X509ChainStatusFlags.UntrustedRoot)
    {
    //Acceptable Status, We want to know if it builds properly.
    }
    else
    {
    return false;
    }
    }
    }
    catch (Exception ex)
    {
    Console.WriteLine(ex);
    return false;
    }
    
    return true;
    }
    }
