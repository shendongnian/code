    using (var context = new MyContext())
    {
       var customers = context.Companies
        .Include(i => i.Clients)
          .ThenInclude(a => a.CountriesOfOperation)
        .ToList();
    }
 
