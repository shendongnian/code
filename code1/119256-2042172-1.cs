    using (var productionEntities = new ProductionEntities())
    {
        var userName = GetUserName();
        var u  = (from usr in productionEntities.UserSet
                  where usr.UserName == userName
                  select new
                  {
                      DeptName = usr.Department.DeptName
                  }).FirstOrDefault();
        if (u == null)
        {
            throw new KpiSecurityException("No local database entry found for user.") { UserName = userName };
        }
        return u.DeptName;
    }
