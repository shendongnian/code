    var profileId = Guid.NewGuid();
    var sessionId = Guid.NewGuid();
    var profile = new Profile
    {
        Id = profileId,
    };
    var session = new Session
    {
        Id = sessionId,
        ProfileId = profileId
    };
    ctx.Profiles.Add(profile);
    ctx.Sessions.Add(session);
    ctx.SaveChanges();
    profile.CurrentSession = session;
    ctx.SaveChanges();
