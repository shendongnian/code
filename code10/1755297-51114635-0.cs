      var counts = 
    	 _db.Users
    	.Select(e => new { AwaitingConfirmation = 
                 u.User.State == AccountState.AwaitingConfirmation ? 1 : 0 })
        .GroupBy(e => 1)
        .Select(g => new
        {
            Count = g.Count(),
            account = g.Sum(e => e.AwaitingConfirmation)
        }).FirstOrDefault();
    	
