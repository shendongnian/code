	private static ICollection<MyClass> GenerateMyClass(int number = 50000){
		var output = new List<MyClass>();
		
		Random r = new Random((int) DateTime.Now.Ticks);
		
		for (int i = 0; i < number; i++)
		{
			var mc = new MyClass { Id = i, AValue = $"Value_{i}" };
			var numberOfLinks = r.Next(1, 10);	
			for(int j = 0; j < numberOfLinks; j++){
				var link = r.Next(0, number-1);
				if(!mc.LinkToIds.Contains(link) && link != mc.Id)
					mc.LinkToIds.Add(link);
			}
			output.Add(mc);
		}
		
		return output;
	}
