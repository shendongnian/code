	public class TrackPoint 
	{
		public int Id { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double TrackId { get; set; }
		public Track Track { get; set; }
	}
	public class Track 
	{
		public double Id { get; set; }
		public double MinLatitude { get; set; }
		public double MaxLatitude { get; set; }
		public double MinLongitude { get; set; }
		public double MaxLongitude { get; set; }
		public ICollection<TrackPoint> TrackPoints { get; set; }
	}
