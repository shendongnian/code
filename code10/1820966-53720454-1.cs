    var result = (from user in db.FindAll(usr => usr.Email.Equals(userLogin.Username) && 
    usr.Password.Equals(userLogin.Password))
    join office in db.FindAll() on user.OfficeId equals office.Id
    select new 
    {
        UserID = user.Id,
        Language = user.Language,
        OfficeId = user.OfficeId,
        IsAllowed = false,
        AlowedUsers = office.AllowedUsers
    }
    ).ToList();
    
    var final = result.Select(c=> new UserDetails {
        UserID = c.Id,
        Language = c.Language,
        OfficeId = c.OfficeId,
        IsAllowed = c.AllowedUsers.Split(",").Contains(user.Id.ToString())
    })
