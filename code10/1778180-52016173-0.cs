      var customerGroups = _context.CustomerGroups.Where(m => m.Customer.User.Email == email)
                    .Include(t => t.Group).
                     Select(s=> new CustomerGroupModel {
                           A= s.A,
                           B= s.B,
                           …
                           Group = s.Group
                     }).ToList();
