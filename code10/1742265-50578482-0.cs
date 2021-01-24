	public class Location
	{
		public string lat { get; set; }
		public string lng { get; set; }
		public List<object> x { get; set; }
		public List<object> y { get; set; }
	}
	public class RootObjectOld
	{
		public object ipv4 { get; set; }
		public Location location { get; set; }
		public string time { get; set; }
	}
