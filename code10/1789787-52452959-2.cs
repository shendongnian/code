    public class OpenWeatherResponse 
    {
		public Coord Coord { get; set; }
		public Main Main { get; set; }
    }
	
	public class Coord
	{
		public float lon { get; set; }
		public float lat { get; set; }
	}
	public class Main
	{
		public float temp { get; set; }
		public int pressure { get; set; }
		public int humidity { get; set; }
		public float temp_min { get; set; }
		public float temp_max { get; set; }
	}
