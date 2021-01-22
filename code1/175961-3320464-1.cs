    protected void Application_Error(object sender, EventArgs e){
      // An error has occured on a .Net page.
      var serverError = Server.GetLastError() as HttpException;
    
      if (null != serverError){
        int errorCode = serverError.GetHttpCode();
    
        if (404 == errorCode){
          Server.ClearError();
          Server.Transfer("/Errors/404.htm");
        }
      }
    }
