    public class FacebookMapper : IMapper
    {
        public IEnumerable<User> MapFacebookAvatars(IEnumerable<User> users)
        {
            var usersByID =
                users.Where(u => u.FacebookUid.HasValue)
                     .ToDictionary(u => u.FacebookUid.Value);
            var facebookUsersByID =
                GetFacebookUsers(usersByID.Keys).ToDictionary(f => f.uid);
            
            foreach(var id in usersByID.Keys.Intersect(facebookUsersByID.Keys))
                usersByID[id].FacebookAvatar = facebookUsersByID[id].pic_sqare;
    
            return users;
        }
    
        public Facebook.user[] GetFacebookUsers(IEnumerable<int> uids)
        {
           // return facebook users for uids using WCF
        }
    }
