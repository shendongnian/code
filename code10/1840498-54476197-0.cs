    var users = ctx.Notes.Where(x => x.UserId == user.UserId);
    
    if (user.FamilyId != null)
    {
        users = users.Union(ctx.Notes.Where(x => x.UserId == user.FamilyId));
    }
    
    if (user.CompanyId != null)
    {
        users = users.Union(ctx.Notes.Where(x => x.UserId == user.CompanyId ));
    }
    
    var result = users.ToArray();
