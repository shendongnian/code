    public static class ViewDataExtensions
    {
       private const string UserInfoKey ="_UserInfo";
 
       public static void GetUserInfo(this ViewData viewData)
       {
         return viewData.ContainsKey(UserInfoKey)
           ? viewData[UserInfoKey] as UserInfo
           : null;
       }
       public static UserInfo SetUserInfo(this ViewData viewData, UserInfo userInfo)
       {
         viewData[UserInfoKey];
       }
    }
