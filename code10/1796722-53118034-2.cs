    public override bool GetAuthCredentials (IWebBrowser browserControl, IBrowser browser, 
                                             IFrame frame, bool isProxy, string host, int port, 
                                             string realm, string scheme, IAuthCallback callback)
    {
      // PSeudo code - asks user & pw 
      (string UserName, string Password) = UIHelper.UIOperation (() =>
      {
        // UI to ask for user && password: 
        // return (user,pw) if input ok else return (null,null)
      });
    
      if (UserName.IsSet () && Password.IsSet ())
      {
        if (!callback.IsDisposed)
        {
          using (callback)
          {
            callback?.Continue (UserName, Password);
          }
          return true;
        }
      }
    
      return base.GetAuthCredentials (browserControl, browser, frame, isProxy, 
                                      host, port, realm, scheme, callback);
    }
