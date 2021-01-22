    using (var db = Datasource.GetContext())
    {
        var customers = from c in db.Customers
                        select new CustomerModelView
                        {
                            Name = c.Name;
                            Address = c.Address;
                        };
    
        CustomerCollection.AddRange(customers);
    }
