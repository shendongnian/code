        public List<UserProfile> GetProfiles()
        {
            using (var ctx = new UserDatabaseEntities())
            {
                var ret = ctx.UserProfiles.Include("UserDelgations").Select(p => p).ToList();
                return ret;
            }
        }
