    var validatedUser = 
        _context.User
        .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
        .Where(x => string.Equals(x.UserName, username, StringComparison.CurrentCultureIgnoreCase) && x.Active)
        .ToList() // Force execution of query here...
        .Select(result => new ValidatedUser // From here on it's client side
        {
            Id = result.Id,
            Email = result.Email,
            FirstName = result.FirstName,
            LastName = result.LastName,
            PhoneNumber = result.PhoneNumber,
            Username = result.UserName,
            UserRoles = result.UserRoles.ToList(),
            Roles = result.UserRoles.Select(ur => ur.Role).ToList(),
            PasswordHash = result.PasswordHash
         }).FirstOrDefault();
 
