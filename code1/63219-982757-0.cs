    public class UserManagerDAO
    {
        public static bool UpdateUser(BM_User user, bool changeLoginDateTime)
        {
            using(BugManDataContext db = new BugManDataContext())
            {
                // lookup the current user in the database.
                var dbUser = (from u in db.Users
                              where u.Id == user.Id
                              select u).Single();
                if (changeLoginDateTime == true)
                {
                    // update all the fields from your passed in user object
                    dbUser.Field1 = user.Field1;
                    dbUser.Field2 = user.Field2;
                    dbUser.Field3 = user.Field3;
                    dbUser.LastLoginDate = DateTime.Now
                    dbUser.LastLoginDate = DateTime.Now;
 
                    db.SubmitChanges();
                    return true;
                }
            }
        }
    }
