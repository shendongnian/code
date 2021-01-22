    public sealed class FacebookMerger : IUserMerger
    {
        public void MergeInformation(IEnumerable<User> users)
        {
            var facebookUsers = GetFacebookUsers(users);
            var uidDictionary = facebookUsers.ToDictionary(fb => fb.uid);
    
            foreach (var user in users)
            {
                FacebookUser fb;
                if (uidDictionary.TryGetValue(user.FacebookUid, out fb)
                {
                    user.Avatar = fb.pic_square;
                }
            }
        }
        private Facebook.user[] GetFacebookUsers(IEnumerable<User> users)
        {
            var uids = (from u in users
                        where u.FacebookUid != null
                        select u.FacebookUid.Value).Distinct().ToList();
    
            // return facebook users for uids using WCF
        }
    }
