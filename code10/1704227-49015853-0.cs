          using (var context = new NorthwindEntities())
            {
                var customers = context.Customers.Where("ContactName.Contains(@0) or ContactName.Contains(@1)", "Maria","Carine").ToList();
                Console.WriteLine(customers.Count);
            }
        
