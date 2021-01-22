    var x = (from c in Context.Customers
             select new {
                 CustomerId = c.CustomerId,
                 Name = c.Name,
                 IncidentsCount = 
                     Context.Customers.Count(i => i.CustomerId == c.CustomerId),
                 OpportunitiesCount = 
                     Context.Opportunities.Count(o => o.CustomerId == c.CustomerId),
                 VisitsCount = 
                     Context.Visits.Count(v => v.CustomerId == c.CustomerId)
             });
