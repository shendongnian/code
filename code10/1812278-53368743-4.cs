    public IActionResult AddUser(AddUserViewModel model)
    {
        // title contains value like: 0, 1, 2... as string
        string title = ((int)model.Title).ToString();
    
        var user = new Users_Accounts
        {
            AccountID = ...
            UniqueID = ...
            Title = title,
            First_Name = model.First_Name,
            Last_Name = model.Last_Name
        };
    
        _dbContext.UserAccounts.Add(user);
    
        _dbContext.SaveChanges();
    }
