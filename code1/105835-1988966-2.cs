    var DB = new DataContext();
    var result = from c in DB.Contacts
                 select new {
                   c.Id
                   c.FirstName,
                   c.LastName,
                   Address = c.PrimaryAddress.Street1 + " " + c.PrimaryAddress.Street2 //...
                   Email = c.PrimaryEmail.Address
                 };
