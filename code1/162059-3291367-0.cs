    IWebProxy Proxya = System.Net.WebRequest.GetSystemWebProxy();
    //to get default proxy settings
    Proxya.Credentials = CredentialCache.DefaultNetworkCredentials;
    Uri targetserver = new Uri(targetAddress);
    Uri proxyserver = Proxya.GetProxy(targetserver);
    HttpWebRequest rqst = (HttpWebRequest)WebRequest.Create(targetserver);
    rqst.Proxy = Proxya;
    rqst.Timeout = 5000;
    try
    {
        //Get response to check for valid proxy and then close it
        WebResponse wResp = rqst.GetResponse();
        //===================================================================
        wResp.Close(); //HERE WAS THE PROBLEM. ADDING THIS CALL MAKES IT WORK
        //===================================================================
    }
    catch(WebException wex)
    {
        connectErrMsg = wex.Message;
        proxyworks = false; 
    }
