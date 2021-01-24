    db.Users.Where(u => u.Name == "John")
                .Where(u => u.Expenses.Any(e => e.Description == "Lunch")
                .Select(u => new
                {
                    u,
                    Expenses= u.Expenses.Where(e => e.Description == "Lunch")
                });
        
