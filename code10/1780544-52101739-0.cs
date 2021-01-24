    namespace HiRatik.Stories.HelperMethods
    {
        public class UserHelperMethods
        {
             public static UserHelperMethods _instance = null;
             public static UserHelperMethods Instance()
             {
               if(_instance == null)
               {
                 _instance = new UserHelperMethods();
               }
               return _instance;
             }
            //checks if the user's profile pic is null and sets it to default pic if it is
            public string GetUserProfilePic(ApplicationUser user)
            {
                if (user.ProfilePic == null)
                {
                    user.ProfilePic = "profile_pic_default.png";
                }
    
                return user.ProfilePic;
            }
        }
    }
