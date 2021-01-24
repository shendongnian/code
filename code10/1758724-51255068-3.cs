	public class Car{
	
		public int Id;
		public Color Color;
		
	}
	
	public class Color
	{
		public int Id;
		public string ColorName;
	}
	
	
	public static void Main()
	{
		var carList = new List<Car> {
			new Car() { Id = 1, Color = new Color {Id = 1, ColorName = "blue" }},
				new Car() { Id = 1, Color = new Color {Id = 1, ColorName = "blue" }},
				new Car() { Id = 1, Color = new Color {Id = 2, ColorName = "red" }},
				new Car() { Id = 1, Color = new Color {Id = 3, ColorName = "green" }},
		};
		
		var carColorMap = carList.GroupBy(x => new {x.Id, ColorId = x.Color.Id}).GroupBy(x => x.Key.Id).ToDictionary(x => x.Key, v => v.Select(x => x.FirstOrDefault()));
		
		foreach(var car in carColorMap)
		{
			Console.WriteLine(car.Key);
			foreach(var color in car.Value)
			
			Console.WriteLine(color.Color.ColorName);
		}
		
	}
