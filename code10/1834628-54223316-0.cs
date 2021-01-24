    for (int i = 0; i < 10; i++)
    {
    	var objectFromProjection = projectedCollection.First(o => o.initialObj == (i % 2 == 0));
    	
        //Always false
    	Console.WriteLine(ReferenceEquals(projectedCollection[0], objectFromProjection));
    	Console.WriteLine(ReferenceEquals(projectedCollection[1], objectFromProjection));
    }
