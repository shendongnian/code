    using (var context = new YourContext())
    {
      var customers = context.Companies
        .Include(c => c.Clients)
        .ToList();
    }
