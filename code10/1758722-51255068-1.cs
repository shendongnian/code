	public class 
    {
		public int Id;
		public string Color;		
	}
	
	public static void Main()
	{
		var carList = new List<Car> {
			new Car() { Id = 1, Color = "blue"},
				new Car() { Id = 1, Color = "blue"},
				new Car() { Id = 1, Color = "red"},
				new Car() { Id = 1, Color = "green"},
		};
		
		var carColorMap = carList.GroupBy(x => new {x.Id, x.Color})
                                 .GroupBy(x => x.Key.Id)
                                 .ToDictionary(x => x.Key, 
                                                v => v.Select(x => x.FirstOrDefault()));
		
		foreach(var car in carColorMap)
		{
			Console.WriteLine(car.Key);
			foreach(var color in car.Value)
			
			Console.WriteLine(color.Color);
		}
		
	}
