    namespace HiRatik.Stories.HelperMethods
    {
        public class UserHelperMethods
        {
            //checks if the user's profile pic is null and sets it to default pic if it is
            public static string GetUserProfilePic(ApplicationUser user)
            {
                if (user.ProfilePic == null)
                {
                    user.ProfilePic = "profile_pic_default.png";
                }
    
                return user.ProfilePic;
            }
        }
    }
