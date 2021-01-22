    public IEnumerable<User> MapFrom(IEnumerable<User> users)
    {
        var facebookUsers = GetFacebookUsers(users).Concat(NullFacebookUsers);
        var uidDictionary = facebookUsers.ToDictionary(fb => fb.uid);
        foreach (var user in users)
        {
            FacebookUser fb;
            if (uidDictionary.TryGetValue(user.FacebookUid, out fb)
            {
                yield return user.WithAvatar(fb.pic_square);
            }
            else
            {
                yield return user;
            }
        }
    }
