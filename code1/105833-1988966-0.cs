    var DB = new DataContext();
    var result = from c in DB.Contacts
                 select new {
                   c.Id
                   c.FirstName,
                   c.LastName,
                   Address = new AddressLite { 
                                   Street1 = c.PrimaryAddress.Street1, 
                                   Street2 = c.PrimaryAddress.Street2, 
                                   City = c.PrimaryAddress.City,
                                   State = go.PrimaryAddress.State,
                                   Country = go.PrimaryAddress.Country },
                   Email = c.PrimaryEmail.Address
                 };
    result.ToList();
