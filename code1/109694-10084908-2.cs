	int colorCount = Enum.GetValues(typeof(Color)).Length;
	int vehicleCount = Enum.GetValues(typeof(Vehicle)).Length;
	var permutations = Enumerable
                       .Range(0, colorCount * vehicleCount)
		                .Select (index => 
                                   new {
				  	                     Index = index + 1,
                    					 Color = (Color)(index / colorCount),
									     Vehicle = (Vehicle)(index % vehicleCount)
								       });
