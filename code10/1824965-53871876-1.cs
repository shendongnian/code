    // or go straight to your average
    var sum = data.GroupBy(e => new
    {
    	e.String1,
    	e.Int1,
    	e.Int2,
    	e.Decimal1,
    }).Average(e => e.Key.Decimal1);
