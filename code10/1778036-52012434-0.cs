    	using (var db = new MyContext(connectionstring))
    	{
    
    		var tbd = (from t in db.Transactions
    		            group t by t.User
    		            into g
    					let platforms = g.GroupBy(tt => tt.Platform.Name)
    					let trantypes = g.GroupBy(tt => tt.TransactionType.Name)
    					select new {
    					   User = g.Key,
    					   Platforms = platforms, 
    					   TransactionTypes = trantypes 
    					}).ToList()
    					.Select(u => new TransactionByDay {
    					    User=u.User, 
    					    Platforms=u.Platforms.ToDictionary(tt => tt.Key, tt => tt.Count()),
    					    TransactionTypes = u.TransactionTypes.ToDictionary(tt => tt.Key, tt => tt.Count())
    					});
     //...
    }
