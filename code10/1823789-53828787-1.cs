    TimeSpan last365Days = TimeSpan.FromDays(365);
    DateTime startTime = DateTime.UtcNow-last365Days;
    var query = dbContext.Customers
        .Where(customer => ...)            // only if you don't want all Customers
        .Select(customer => new
        {
             // select only the Customer properties you actually plan to use
             Id = Customer.Id,
             Name = Customer.Name,
             // total time spent in ticks (consider using seconds, minutes, ...)
             TimeSpentTicks = customer.Appearances
                 // keep only appearances in the last 365 days
                 .Where(appearance.StartTime >= startTime)
                 // the time spent during this appearance in ticks
                 .Select(appearance => (appearance.EndTime - appearance.StartTime).Ticks)
                 // Sum these ticks
                 .Sum(),
              // to calculate the number of days:
              // from StartTime and EndTime take the day number of the year
              // keep distinct day number
              // and count the number of distinct day numbers
              NumberOfAppearanceDays = customer.Appearances
                  .SelectMany(appearance => new
                  {
                      appearance.StartTime.DayOfYear,
                      appearance.EndTime.DayOfYear,
                  })
                  .Distinct()
                  .Count(),
        });
