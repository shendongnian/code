    IQueryable<Customer> customers = ...
    IQueryable<Appearance> appearances = ...
        .Where(appearance.StartTime >= startTime);
    var query = customers.GroupJoin(appearances,   // GroupJoin customers and appearances
        customer => customer.Id,                   // from every customer take the Id
        appearance => appearance.CustomerId,       // from every appearance take the CustomerId
        (customer, appearances) => new              // from every customer with all his 
        {                                           // appearances, make one new object
             Id = Customer.Id,
             Name = Customer.Name,
             TimeSpentTicks = appearances
                 .Select(appearance => (appearance.EndTime - appearance.StartTime).Ticks)
                 .Sum(),
              NumberOfAppearanceDays = appearances
                  .SelectMany(appearance => new
                  {
                      appearance.StartTime.DayOfYear,
                      appearance.EndTime.DayOfYear,
                  })
                  .Distinct()
                  .Count(),
        });
