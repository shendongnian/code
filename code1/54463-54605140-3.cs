    // declarative query syntax
    var result3 = 
    	from x in table
    	group x by new { x.Column1, x.Column2 } into g
    	select new { g.Key.Column1, g.Key.Column2, QuantitySum = g.Sum(x => x.Quantity) };
    
    // or method syntax
    var result4 = table.GroupBy(x => new { x.Column1, x.Column2 })
    	.Select(g => 
          new { g.Key.Column1, g.Key.Column2 , QuantitySum= g.Sum(x => x.Quantity) });
