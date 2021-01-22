    var data = new[] {
    	new { Id = 1, Price = 2 },
    	new { Id = 1, Price = 10 },
    	new { Id = 2, Price = 30 },
    	new { Id = 3, Price = 50 },
    	new { Id = 4, Price = 120 },
    	new { Id = 5, Price = 200 },
    	new { Id = 6, Price = 1024 },
    };
    var ranges = new[] { 10, 50, 100, 500 };
    
    var grouped = data.GroupBy( x => ranges.FirstOrDefault( r => r > x.Price ) );
