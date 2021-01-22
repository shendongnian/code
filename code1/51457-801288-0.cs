    public bool ValidateServerCertificate( object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
    // No errors so continue…
    if (sslPolicyErrors == SslPolicyErrors.None)
           return true;
    
    // I’m just logging it to a label on the page, 
    //  this should be stored or logged to the event log at this time. 
    lblStuff.Text += string.Format("Certificate error: {0} <BR/>", sslPolicyErrors);
     
    // If the error is a Certificate Chain error then the problem is
    // with the certificate chain so we need to investigate the chain 
    // status for further info.  Further debug capturing could be done if
    // required using the other attributes of the chain.
          if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors)
          {
           foreach (X509ChainStatus status in chain.ChainStatus)
           {
                 lblStuff.Text += string.Format("Chain error: {0}: {1} <BR/>", status.Status, status.StatusInformation);
      }
    }
    
    // Do not allow this client to communicate 
    //with unauthenticated servers.
          return false;
    }
