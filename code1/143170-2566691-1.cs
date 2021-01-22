    db.GetAllContactsQuery()
        .AsEnumerable().
        .Select(c=>
            {
               ID= c.ID,
               LastName = c.LastName,
               FirstName = c.FirstName,
               Email = c.Email,
               City =MyClrMethod(c.City,c.State)
            })
