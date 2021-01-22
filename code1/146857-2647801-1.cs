    public class UserPresenceRepository
    {
        public UserPresenceRepository(string connString)
        {
            // configure db properties
        }
        
        public UserPresence GetPresence(User user)
        {
            // get precense from user.accountId if possible 
            // and skip the trip for Account
        }
    }
