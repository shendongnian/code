    if (context.Coffee .Any())
            {
                return;   // DB has been seeded
            }
     var coffees = new Coffee []
            {
                new Coffee { Name = "Coffee name",   ImagePath = "/[your path]",
                    Price = "[price]", Description ="description" },
                 new Coffee {......................}
             }
           foreach (Coffee coffee in coffees)
            {
                context.Coffee.Add(coffee);
            }
            context.SaveChanges();
