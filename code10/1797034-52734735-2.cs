	public class Pressure
	{
		public int speed { get; set; }
		public string IpAddress { get; set; }
		public int TcpPort { get; set; }
		public int UnitId { get; set; }
	}
	public class Engage
	{
		public int Interval { get; set; }
		public string IpAddress { get; set; }
		public int TcpPort { get; set; }
		public int UnitId { get; set; }
	}
	public class Volume
	{
		public int density { get; set; }
		public string IpAddress { get; set; }
		public int Port { get; set; }
	}
	public class Operations
	{
		public Pressure pressure { get; set; }
		public Engage Engage { get; set; }
		public Volume Volume { get; set; }
	}
	public class Tr984
	{
		public Operations Operations { get; set; }
	}
	public class Configurations
	{
		public Tr984 Tr984 { get; set; }
	}
	public class RootObject
	{
		public Configurations Configurations { get; set; }
	}
