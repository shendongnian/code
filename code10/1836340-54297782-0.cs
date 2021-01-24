    var presenceData = _Context.UserProfile.GroupBy(x => 0)
        .Select(g => new
        {
            IsMailIdAlreadyExist = g.Any(x => x.Email == myModelUserProfile.Email),
            IsUserNameAlreadyExist = g.Any(x => x.Username == myModelUserProfile.Username),
        }).First();
