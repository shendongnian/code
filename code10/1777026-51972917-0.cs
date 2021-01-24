     private void CheckForUserType()
     {
        var user = RetrieveSession();
     }
     private UserInfo RetrieveSession()
     {
        UserInfo userInfo = new UserInfo(HttpContext.Current.Session["userInfo"]);
        return userInfo;
     }
