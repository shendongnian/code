    // Input
    List<double[]> a = new List<double[]>() { 
    	new double[]{ 1.0, 2.0, 3.0 },
    	new double[]{ 4.0, 5.0, 6.0 },
    	new double[]{ 7.0, 8.0, 9.0 }
    };
    // Output
    var b = a.Select((item, index) => new 
				{ 
					Items = item.Select((inner, inIndex) => new { Inner = inner, Y = inIndex }),
					X = index 
				})
				.SelectMany(item => item.Items, (i, inner) => new { Value = inner.Inner, X = i.X, Y = inner.Y })
				.Aggregate(new double[a.Count, a.Max(aa => aa.Length)], (acc, item) => { acc[item.X, item.Y] = item.Value; return acc; })
