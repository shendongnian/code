    var loginUser = 
        from user in db.FindAll(usr => usr.Email.Equals(userLogin.Username) && usr.Password.Equals(userLogin.Password))
        join office in db.FindAll() on user.OfficeId equals office.Id
        select new { user, office };
    var userDetails = from u in loginUser.AsEnumerable()
        select new UserDetails()
        {
            UserID = u.user.Id,
            Language = u.user.Language,
            OfficeId = u.user.OfficeId,
            IsAllowed = u.office.AllowedUsers.Split(',').Contains(u.user.Id.ToString())
        };
 
