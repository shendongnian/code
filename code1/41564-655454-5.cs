    .. In UserFactory...
     Save(int? userId, string userName, string password, string eMail, string selvalue)
     {
         // code to process input parameters and save/update user
         userName = userName.Trim().ToLower();
         password = password.Trim().ToLower();
         eMail    = eMail.Trim().ToLower();
         selvalue = selvalue.Trim().ToLower();
         IUser user = UserFactory.getInstance().createUser(
                       userId, username, password, 
                       email,status);
         user.Save();         
     }
