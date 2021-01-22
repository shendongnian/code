    .. In UserFactory...
     Save(int? userId, string userName, string password, 
             string eMail, string selvalue)
     {
         // code to process input parameters and save/update user
         userName = userName.Trim().ToLower();
         password = password.Trim().ToLower();
         eMail    = eMail.Trim().ToLower();
         selvalue = selvalue.Trim().ToLower();
         IUser user = userId.HasValue?
                        UserFactory.getInstance().createUser(
                                userId.Value, username, password, 
                                email,status):
                        UserFactory.getInstance().createUser(
                                username, password, 
                                email, status);
         try { user.Save(); }
         catch(DBException dbX)  //   catch/rethrow Database exception 
                                 //   as custom expcetion here
         {
             throw new MyCustomAppException(
                     "Save User failed: + dbX.Message",
                     dbX);
         }  
     }
