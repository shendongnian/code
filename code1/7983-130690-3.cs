    public ServiceAuthHeader AuthenticationSoapHeader;
    [WebMethod]
    [SoapHeader("AuthenticationSoapHeader")]
    [AuthenticationSoapExtension]
    public string GetSomeStuffFromTheCloud(string IdOfWhatYouWant)
    {
      return WhatYouWant;
    }
