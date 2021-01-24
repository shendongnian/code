    public override bool OnCertificateError (IWebBrowser browserControl, IBrowser browser, 
                                             CefErrorCode errorCode, string requestUrl, 
                                             ISslInfo sslInfo, IRequestCallback callback)
    {
      Log.Logger.Warn (sslInfo.CertStatus.ToString ());
      Log.Logger.Warn (sslInfo.X509Certificate.Issuer);
      if (CertIsTrustedEvenIfInvalid (sslInfo.X509Certificate))
      {
        Log.Logger.Warn ("Trusting: " + sslInfo.X509Certificate.Issuer);
        if (!callback.IsDisposed)
          using (callback)
          {
            callback?.Continue (true);
          }
        return true;
      }
      else
      {
        return base.OnCertificateError (browserControl, browser, errorCode, requestUrl,
                                        sslInfo, callback);
      }
    }
