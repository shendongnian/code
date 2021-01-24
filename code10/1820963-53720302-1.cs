    var loginUser = 
        from user in db.FindAll(usr => usr.Email.Equals(userLogin.Username) && usr.Password.Equals(userLogin.Password))
        join office in db.FindAll() on user.OfficeId equals office.Id;
    var userDetails = from user in loginUser.AsEnumerable()
        select new UserDetails()
        {
            UserID = user.Id,
            Language = user.Language,
            OfficeId = user.OfficeId,
            IsAllowed = office.AllowedUsers.Split(',').Contains(user.Id.ToString())
        };
 
