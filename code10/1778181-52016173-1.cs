      var customerGroups = _context.Customer.Where(m => m.User.Email == email)
                    .Include(r => r.CustomerGroups).ThenInclude(t => t.Group).
                     Select(s=> new CustomerGroupModel {
                           A= s.CustomerGroups.A,
                           B= s.CustomerGroups.B,
                           …
                           Group = s.CustomerGroups.Group
                     }).ToList();
