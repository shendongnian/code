    var result = myDbContext.Users               // From the collection of all Users
        .Where(user => user.Name == ...)         // Select only those that have a name ...
        .Select(user => new                      // from every remaining user make one new object
        {
            // Select only the properties you actually plan to use:
            Id = user.Id,
            Name = user.Name,
            ...
            Expenses = user.Expenses
                .Where(expense => expense.Description == ...)
                .Select(expense => new
                {
                     // again, select only the properties you plan to use
                     Id = expense.Id,   
                     Description = expense.Description,
                     // not needed, you know it equals user.Id:
                     // UserId = expense.UserId
                     ...
                })
                .ToList(),
        });
