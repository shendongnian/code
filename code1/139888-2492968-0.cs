    string userType = Authentication(Login2.UserName, Login2.Password);
    if(userType != string.IsNullOrEmpty)
    {
      if(userType.Equals("yourType")
        Response.Redirect("firstSite.aspx");
      elseif //...etc
    }
