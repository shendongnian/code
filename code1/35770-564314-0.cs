    NameValueCollection nvc = Request.Form;
    string userName, password;
    if (!string.IsNullOrEmpty(nvc["txtUserName"]))
    {
      userName = nvc["txtUserName"];
    }
    
    if (!string.IsNullOrEmpty(nvc["txtPassword"]))
    {
      password = nvc["txtPassword"];
    }
    
    //Process login
    CheckLogin(userName, password);
