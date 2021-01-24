	public class Planet
	{
		public List<Mine> Mines { get; set; }
	}
	public class Mine
	{
		public string Type { get; set; }
		public int Level { get; set; }
	}
	var planets = new Dictionary<string, Planet>();
	planets[Planet.CharacterId] = new Planet
	{
		Mines = new List<Mine>
		{
			new Mine
			{
				Type = "Metal",
				Level = 0
			}
		};
	}
