    string unitNames = string.Join(", ", afimDB.UNITES
        .Where(a => a.UNIT_ID == 2)
        .Select(a => a.UNIT_NAME));
    
    var usersWithEntities = (
        from user in imdb.AspNetUsers
        select new Users_in_Entities_ViewModel
        {
            UserId = user.Id,
            Username = user.UserName,
            Email = user.Email,
            Entity = unitNames 
        });
