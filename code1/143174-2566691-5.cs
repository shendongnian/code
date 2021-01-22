    db.GetAllContactsQuery()
        .AsEnumerable()
        .Select(c=>new
            {
               ID= c.ID,
               LastName = c.LastName,
               FirstName = c.FirstName,
               Email = c.Email,
               City =MyClrMethod(c.City,c.State)
            })
If db.GetAllContactsQuery() returns many additional fields, select the ones of interest before the AsEnumerable clause to narrow bandwidth requirements.
