    class Program
	{
		static void Main(string[] args)
		{
			var cars = new List<Car>
			{
				new Car { Year = 2009, Make = "Ford", Model = "Explorer" },
				new Car { Year = 2001, Make = "Hummer", Model = "H1" },				
				new Car { Year = 2002, Make = "Ford", Model = "Focus" },
				new Car { Year = 2008, Make = "BMW", Model = "325i" },
				new Car { Year = 2008, Make = "Ford", Model = "Explorer" },				
				new Car { Year = 2008, Make = "Ford", Model = "Escape" },				
				new Car { Year = 2009, Make = "Mitsubishi", Model = "Galant" },
				new Car { Year = 2004, Make = "Ford", Model = "Explorer" },
				new Car { Year = 2009, Make = "BMW", Model = "329i" },
				new Car { Year = 2003, Make = "Ford", Model = "Explorer" }				
			};
			var groupedByFordExplorer = from c in cars
										let isFordExplorer = c.Make == "Ford" && c.Model == "Explorer"
										orderby isFordExplorer, c.Year
										select c;
			foreach (var car in groupedByFordExplorer)
			{
				Console.WriteLine("{0} {1} {2}", car.Year, car.Make, car.Model);
			}
			Console.ReadLine();
		}
	}
	class Car
	{
		public int Year { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
	}
