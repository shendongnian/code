    var validatedUser = 
        _context.User
        .Where(x => string.Equals(x.UserName, username, StringComparison.CurrentCultureIgnoreCase) && x.Active)
        .Select(result => new ValidatedUser
        {
            Id = result.Id,
            Email = result.Email,
            FirstName = result.FirstName,
            LastName = result.LastName,
            PhoneNumber = result.PhoneNumber,
            Username = result.UserName,
            Roles = result.UserRoles.Select(ur => ur.Role),
            PasswordHash = result.PasswordHash
         }).FirstOrDefault();
