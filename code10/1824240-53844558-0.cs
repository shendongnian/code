    var users = DbContext.Users
               .Include(x => x.ApplicationUserGroups)
                    .ThenInclude(x => x.ApplicationGroup)
               .Where(x => true);
    
    foreach (var user in users) {
        var latest = DbContext.FormSubmits.Include(s => s.FormLevel).Where(s => s.UserId == user.UserId).OrderByDescending(i => i.CreationDate).FirstOrDefault()
        //Do other stuff...
    }
