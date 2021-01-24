    var result = myDbContext.Users
        .Where(user => user.Name == ...)
        .Select(user => new User()
        {
            // Select only the properties you actually plan to use:
            Id = user.Id,
            Name = user.Name,
            ...
            Expenses = user.Expenses
                .Where(expense => expense.Description == ...)
                .Select(expense => new Expense()
                {
                     // again, select only the properties you plan to use
                     Id = expense.Id,   
                     Description = expense.Description,
                     ...
                })
                .ToList(),
        });
