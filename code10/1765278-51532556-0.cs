    select new AccountViewModel
    {
        AccountName = a.AccountName,
        AllUsers = Users.ToList(),
        ActiveUsers = ms.GetConsumed(),
        // etc.
    }
