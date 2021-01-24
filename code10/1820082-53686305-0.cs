    var users = _context.Appointments
                    .Where(p => p.userId == userId)
                    .GroupBy(p => p.Email) 
                    .Where(g => g.Count() == 1) // if there is only one object with this email, then retain it otherwise discard it
                    .Select(g => g.First())
                    .Select(p => new MyUserModel
                    {
                        Id = p.Id,
                        ...
                        Email = p.User.Email
                        ...
                    });
    return users.ToList();                     
                
