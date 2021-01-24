    // I want to sum it over first dimension.
    var firstDimensionSums = tab
    	.Aggregate((a, b) => Enumerable.Range(0, Math.Min(a.Length, b.Length))
    		.Select(i0 => Enumerable.Range(0, Math.Min(a[i0].Length, a[i0].Length))
    			.Select(i1 => a[i0][i1] + b[i0][i1])
    			.ToArray())
    		.ToArray());
    
    // I want to sum it over second dimension.
    var secondDimensionSums = tab
    	.Select(nested => nested
    		.Aggregate((a,b) => Enumerable.Range(0, nested.Min(x => x.Length))
    			.Select(index => a[index] + b[index])
    			.ToArray()))
    	.ToArray();
