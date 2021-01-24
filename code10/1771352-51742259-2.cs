	public class Coordinates
	{
		public string Longitude { get; set; }   //coord.lon for opw
		public string Latitude { get; set; }    //coord.lat for opw
	}
	public class Weather
	{
		public string Summary { get; set; }     //weather.main for opw
		public string Description { get; set; }
		public double Visibility { get; set; }  // only for  DS
	} 
    // A composed class 
	public class WeatherData
	{
		public Coordinates Coordinates { get; set; }
		public Weather Weather { get; set; }
	}
	
