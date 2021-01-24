        using (var context2 = new TestDbContext())
        {
            var ids = context2.Customers
                .Where(x => x.Name == "Fred")
                .Select(x => x.CustomerId)
                .AsEnumerable();
            using (var context = new TestDbContext())
            {
                var customers = context.Customers.Where(x => ids.Contains(x.CustomerId))
                    .ToList();
            }
        }
