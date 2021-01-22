    User u = (from usr in productionEntities.UserSet
              where usr.UserName == userName
              select usr).FirstOrDefault();
    if (u == null)
    {
            throw new KpiSecurityException("No local database entry found for user.") { UserName = userName };
    }
    
    if (!u.RoleReference.IsLoaded)
    { u.RoleReference.Load(); }
    
    if (!u.DeparmentReference.IsLoaded)
    { u.DeparmentReference.Load(); }
