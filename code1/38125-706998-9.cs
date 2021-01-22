    public sealed class FacebookMapper : IMapper
    {
        private static readonly IEnumerable<FacebookUser> NullFacebookUsers =
            Enumerable.Repeat(new FacebookUser(null), 1);
        public IEnumerable<User> MapFrom(IEnumerable<User> users)
        {
            var facebookUsers = GetFacebookUsers(users).Concat(NullFacebookUsers);
            return from user in users
                   join facebookUser in facebookUsers on
                        user.FacebookUid equals facebookUser.uid
                   select user.WithAvatar(facebookUser.pic_square);
        }
    
        private Facebook.user[] GetFacebookUsers(IEnumerable<User> users)
        {
            var uids = (from u in users
                        where u.FacebookUid != null
                        select u.FacebookUid.Value).ToList();
    
            // return facebook users for uids using WCF
        }
    }
