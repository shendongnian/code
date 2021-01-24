    var isDuplicated = clients.Join(employees, 
           c => new { c.Name, c.FirstName }, 
           e => new { e.Name, e.FirstName },
           (c, e) => new { c, e })
           .Any();
