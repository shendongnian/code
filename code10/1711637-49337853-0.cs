    //a.Value is the Account class instance from each dictionary entry
    var acclist = accSavingList.Select( a => new {
        AccountNo = a.Key,
        AccountName = a.Value.AccountName,
        Balance = a.Value.Balance,
        MinimumBalance = a.Value.MinimumBalance
    }).ToList();
   
    gridView.DataSource = acclist;
