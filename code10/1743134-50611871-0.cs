	public class Properties
	{
		public string Type { get; set; }
		
		[JsonProperty(PropertyName = "R_STATEFP")]
		public string RState { get; set; }
		
		[JsonProperty(PropertyName = "L_STATEFP")]
		public string LState { get; set; }
	}
	public class Geometry
	{
		public string Type { get; set; }	
		public List<List<double>> Coordinates { get; set; }
	}
	public class Feature
	{
		public string Type { get; set; }
		public Properties Properties { get; set; }
		public Geometry Geometry { get; set; }
	}
	public class RootObject
	{
		public string Type { get; set; }
		public List<Feature> Features { get; set; }
	}
