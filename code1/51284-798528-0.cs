    WebService.ManageOutboundDelivery oWS = new WebService.ManageOutboundDelivery();
   
    if (My.Settings.HasClientCert == true) {
        X509Certificate2 signedCert = new X509Certificate2(HttpContext.Current.Server.MapPath(My.Settings.ClientCertName), My.Settings.ClientCertPW);
        oWS.ClientCertificates.Add(signedCert);
    }
   
    System.Net.CredentialCache oCred = new System.Net.CredentialCache();
    Net.NetworkCredential netCred = new Net.NetworkCredential(My.Settings.WebServiceUID, My.Settings.WebServicePW);
   
    oCred.Add(new Uri(oWS.Url), "Basic", netCred);
    oWS.Credentials = oCred;
