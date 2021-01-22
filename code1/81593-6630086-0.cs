    var sslFailureCallback = new RemoteCertificateValidationCallback(delegate { return true; });
    
    try
    {
        
        if (ignoreSslErrors)
        {
            ServicePointManager.ServerCertificateValidationCallback += sslFailureCallback;
        }
    
        response = webClient.UploadData(Options.Address, "POST", Encoding.ASCII.GetBytes(Options.PostData));
    
    }
    catch (Exception err)
    {
        PageSource = "POST Failed:\r\n\r\n" + err;
        return PageSource;
    }
    finally
    {
        if (ignoreSslErrors)
        {
            ServicePointManager.ServerCertificateValidationCallback -= sslFailureCallback;
        }
    }
