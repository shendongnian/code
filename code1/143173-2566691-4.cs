    from c in db.GetAllContactsQuery()
    select new
    {
       ID= c.ID,
       LastName = c.LastName,
       FirstName = c.FirstName,
       Email = c.Email,
       City =(c.City??"")+" "+(c.State??"")
    }
